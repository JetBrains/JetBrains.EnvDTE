# Visual Studio EnvDTE Project Model

## Properties

### TODO

## Project Item Hierarchy

- Visual Studio solution folders are modeled as special projects.
- The items inside a solution folder are called *solution items* and are stored inside solution folder's `ProjectItems` property, as `ProjectItem` entries.
- Solution items don’t have their own child `ProjectItems` and if you want to navigate down the hierarchy, you need to access their `Object` or `SubProject` properties.
- If a solution item represents a regular file, its `Object` and `SubProject` will be `null`, and unlike regular files which are part of a project that are of *PhysicalFile* project item kind, this one will just be of *SolutionItem* project item kind.  
- If a solution item represents another (nested) solution folder, or more precisely, a project representing a solution folder, the same things apply as to top level solution folder.
- if a solution item represents a regular project, the rest of its contents are the same, and are not affected by the fact that it is stored inside the solution folder. One exception is the `ParentProjectItem` property which will be set to the containing solution item, while this property is not set for regular projects, outside of the solution folder


#### Relevant types and their GUIDs

Project types (`Project.Kind`):
- Solution folder project: `{66A26720-8FB5-11D2-AA7E-00C04F688DDE}`

Project item types (`ProjectItem.Kind`):
- Solution item: `{66A26722-8FB5-11D2-AA7E-00C04F688DDE}`

Project item**s** types (`ProjectItems.Kind`):
- Solution folder project items: `{66A26721-8FB5-11D2-AA7E-00C04F688DDE}`
- Regular project items: `{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}` (same as physical folder project item kind?)