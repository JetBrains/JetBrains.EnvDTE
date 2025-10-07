# EnvDTE Implementation

## Project Model

Visual Studio's new project system is open source and available at [dotnet/project-system](https://github.com/dotnet/project-system). This repository is useful for understanding the project model and implementing EnvDTE functionality.

The new project system applies only to:
- .NET SDK-style projects (C#, F#, and VB)
- Shared Projects (C# and VB)

The legacy project system is used for:
- Non-SDK-style .NET projects
- C++ projects
- Other project types

Implementing support for legacy project types is more complex because functionalities are encapsulated in COM objects. Even the modern project system has some COM interop, which makes understanding things harder.

<hr>

### Properties

Both regular and configuration project properties are implemented based on Visual Studio's modern project system. This means:
- **SDK-style .NET projects**: Full compatibility with property implementation
- **Non-SDK-style .NET projects**: Partial compatibility - The available property set differs, but the backend implementation is compatible
- **C++ projects**: Incompatible property sets and backend implementation

#### Implementation Details

**Property Types**

| Type | Status | Notes                                            |
|------|--------|--------------------------------------------------|
| String | Implemented |                                                  |
| Boolean | Implemented |                                                  |
| Integer | Implemented |                                                  |
| UInt | Implemented |                                                  |
| Enum | Implemented |                                                  |
| DynamicEnum | Partial | Implemented, but value providers not implemented |
| StringList | Not Implemented | Not needed for now |

**Property Characteristics**
- Properties can be **read-only** or **writable**
- Visual Studio returns a null property object when the referenced property doesn't exist
- Visual Studio property names differ from MSBuild property names in some cases, requiring explicit mapping. The mappings are defined in: `VisualStudioProjectProperties.cs` and `VisualStudioConfigurationProperties.cs`

**Property Sources**

Regular project properties are sourced from Visual Studio's [GeneralBrowseObject.xaml](https://github.com/dotnet/project-system/blob/9475b6468a9f9b1b627f62d9d9225d23c02e5a49/src/Microsoft.VisualStudio.ProjectSystem.Managed/ProjectSystem/Rules/GeneralBrowseObject.xaml). The mapping in `VisualStudioProjectProperties.cs` is based on this file.

Configuration properties are sourced from [AbstractProjectConfigurationProperties.cs](https://github.com/dotnet/project-system/blob/abeccf3f0693bff5e1edc8dc3120a8d8748069a5/src/Microsoft.VisualStudio.ProjectSystem.Managed.VS/ProjectSystem/VS/Properties/AbstractProjectConfigurationProperties.cs) and language-specific derived classes.
EnvDTE in VS does not support configuration properties for C++ projects, and has only one property for F# projects.

<hr>

### Project Item Hierarchy

#### Overview

The `Solution` object contains all top-level projects, including:
- Regular projects
- Solution folders
- Miscellaneous Files project

**Note:** Projects nested inside solution folders are **not** included.

Every project (or project item) maintains bidirectional references:
- **Parent reference**: Points to the containing item
- **Children references**: Points to contained items

While Visual Studio and Rider have similar hierarchies, there are differences in how solution folders are implemented.

#### Solution Folders

Both Visual Studio and Rider model solution folders as special projects.

In Visual Studio, items within a solution folder are called **solution items** and are stored in the solution folder's `ProjectItems` collection as `ProjectItem` entries. These solution items are wrapper objects that don't exist in Rider. Solution items don't have their own `ProjectItems` collection and to navigate deeper into the hierarchy you need to access the `Object` or `SubProject` property.

**Solution Item Types**

1. **Regular Files**
   - `Object` and `SubProject` property are `null`
   - `Kind`: `SolutionItem` (not `PhysicalFile` like regular project files)

2. **Nested Solution Folders**
   - Behave the same as top-level solution folders
   - The `Object` and `SubProject` property contain the solution folder project

3. **Regular Projects**
   - Project contents are unaffected by being nested in a solution folder with only exception being the `ParentProjectItem` property, which is set to the containing solution item
   - The `Object` and `SubProject` property contain the actual project

**Relevant Type GUIDs**

Project Types (`Project.Kind`)

| Type | GUID |
|------|------|
| Solution Folder | `{66A26720-8FB5-11D2-AA7E-00C04F688DDE}` |

Project Item Types (`ProjectItem.Kind`)

| Type | GUID |
|------|------|
| Solution Item | `{66A26722-8FB5-11D2-AA7E-00C04F688DDE}` |

Project Items Collection Types (`ProjectItems.Kind`)

| Type | GUID | Notes |
|------|------|-------|
| Solution Folder Project Items | `{66A26721-8FB5-11D2-AA7E-00C04F688DDE}` | |
| Regular Project Items | `{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}` | Same as Physical Folder project item kind |