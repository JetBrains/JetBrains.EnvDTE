package model

import com.jetbrains.rd.generator.nova.csharp.CSharp50Generator
import com.jetbrains.rd.generator.nova.setting
import com.jetbrains.rd.generator.nova.*
import com.jetbrains.rd.generator.nova.PredefinedType.*

object DteRoot : Root() {
    override val isLibrary = false
    init {
        setting(CSharp50Generator.ClassAttributes, emptyArray())
    }
}

@Suppress("unused")
object DteProtocolModel : Ext(DteRoot) {
    val projectItemModel = structdef {
        field("id", int)
    }

    val projectItemRequest = openstruct {
        field("projectItemModel", projectItemModel)
    }

    val projectItemKindModel = enum {
        +"Unknown"
        +"PhysicalFile"
        +"PhysicalFolder"
        +"Project"
        +"VirtualDirectory"
    }

    val languageModel = enum {
        +"Unknown"
        +"CSharp"
        +"VB"
        +"Cpp"
        +"JS"
        +"JSON"
        +"JSX"
    }

    val codeElementModel = structdef {
        field("TypeId", int)
        field("Id", int)
    }

    val access = enum {
        +"Public"
        +"Private"
        +"Protected"
        +"Internal"
        +"ProtectedInternal"
        +"PrivateProtected"
        +"None"
    }

    private val addExistingItemRequest = openstruct extends projectItemRequest {
        field("path", string)
        field("isDirectory", bool)
    }

    private val rdSolutionConfiguration = structdef {
        field("name", string)
        field("platform", string)
    }

    val ItemOperations_open_FileRequest = structdef {
        field("fileName", string)
        field("viewKind", string)
    }

    val ideWindow = structdef {
        // TODO
    }

    init {
        createDteCallbacks()
        createSolutionCallbacks()
        createProjectCallbacks()
        createProjectItemCallbacks()
        createProjectItemsCallbacks()
        createFileCodeModelCallbacks()
        createCodeElementCallbacks()
    }

    private fun createProjectItemsCallbacks() {
        // see ProjectItemsProvider
        call("ProjectItems_addFromFile", addExistingItemRequest, projectItemModel.nullable)
        call("ProjectItems_addFromFileCopy", addExistingItemRequest, projectItemModel.nullable)
        call("ProjectItems_addFromDirectory", addExistingItemRequest, projectItemModel.nullable)
        call("ProjectItems_addFolder", structdef("ProjectItems_addFolderRequest") extends projectItemRequest {
            field("name", string)
        }, projectItemModel.nullable)
    }

    private fun createDteCallbacks() {
        // see DteCallbackProvider
        call("DTE_Name", void, string)
        call("DTE_FileName", void, string)
        call("DTE_CommandLineArgs", void, string)

        // See ItemOperationsProvider
        call("ItemOperations_open_File", ItemOperations_open_FileRequest, ideWindow)
        call("ItemOperations_isOpen_File", ItemOperations_open_FileRequest, bool)
    }

    private fun createSolutionCallbacks() {
        // see SolutionCallbackProvider
        call("Solution_FileName", void, string)
        call("Solution_Count", void, int)
        call("Solution_Item", int, projectItemModel.nullable)
        call("Solution_get_Projects", void, immutableList(projectItemModel))
        call("Solution_get_Property", string, string.nullable)
        call("Solution_set_Property", structdef("Solution_setPropertyRequest") {
            field("name", string)
            field("value", string.nullable)
        }, void)
        call("Solution_find_ProjectItem", string, structdef("Solution_find_ProjectItemResponse") {
            field("projectItem", projectItemModel)
            field("projectPath", immutableList(projectItemModel))
        }.nullable)
        call("Solution_get_StartupProjects", void, immutableList(string))

        // SolutionBuild
        call("Solution_get_BuildState", void, enum("RdBuildState") {
            +"NotStarted"
            +"InProgress"
            +"Done"
        })
        call("Solution_get_LastBuildInfo", void, int)
        call("Solution_build", structdef("Solution_buildRequest") {
            field("waitForBuild", bool)
            field("buildSessionTarget", enum("RdBuildSessionTarget") {
                +"Build"
                +"Clean"
            })
        }, void)
        call("Solution_get_ConfigurationCount", void, int)
        call("Solution_get_ActiveConfiguration", void, rdSolutionConfiguration.nullable)
        call("Solution_set_ActiveConfiguration", rdSolutionConfiguration, void)
        call("Solution_get_ConfigurationByIndex", int, rdSolutionConfiguration.nullable)
        call("Solution_get_ConfigurationByName", string, rdSolutionConfiguration.nullable)
    }

    private fun createProjectCallbacks() {
        // see ProjectCallbackProvider
        call("Project_get_Name", projectItemRequest, string)
        call("Project_set_Name", structdef("Project_set_NameRequest") extends projectItemRequest {
            field("newName", string)
        }, void)
        call("Project_get_FileName", projectItemRequest, string)
        call("Project_get_UniqueName", projectItemRequest, string)
        call("Project_get_Kind", projectItemRequest, string)
        call("Project_get_Language", projectItemRequest, languageModel)

        call("Project_get_Property", structdef("Project_get_PropertyRequest") extends projectItemRequest {
            field("name", string)
        }, string.nullable)
        call("Project_set_Property", structdef("Project_set_PropertyRequest") extends projectItemRequest {
            field("name", string)
            field("value", string.nullable)
        }, void)

        call("Project_is_CPS", projectItemRequest, bool)
        call("Project_Delete", projectItemRequest, void)

        // Configuration
        call("Project_get_ConfigurationNames", projectItemRequest, immutableList(string))
        call("Project_get_PlatformNames", projectItemRequest, immutableList(string))
        call("Project_get_ConfigurationCount", projectItemRequest, int)
        call("Project_get_IsBuildable", projectItemRequest, bool)
        call("Project_get_IsDeployable", projectItemRequest, bool)
        call("Project_get_ActiveConfigPlatformName", projectItemRequest, string.nullable)
        call("Project_get_ActiveConfigName", projectItemRequest, string.nullable)
    }

    private fun createProjectItemCallbacks() {
        // see ProjectItemCallbackProvider
        call("ProjectItem_get_Name", projectItemRequest, string)
        call("ProjectItem_set_Name", structdef("ProjectItem_set_NameRequest") extends projectItemRequest {
            field("newName", string)
        }, void)
        call("ProjectItem_get_Kind", projectItemRequest, projectItemKindModel)
        call("ProjectItem_get_ProjectItems", projectItemRequest, immutableList(projectItemModel))
        call("ProjectItem_get_ProjectItemCount", projectItemRequest, int)
        call("ProjectItem_get_Language", projectItemRequest, languageModel)
        call("ProjectItem_remove", projectItemRequest, void)
        call("ProjectItem_get_SubItemIndex", structdef("ProjectItem_getSubItemIndexRequest") extends projectItemRequest {
            field("name", string)
        }, int.nullable)
    }

    private fun createFileCodeModelCallbacks() {
        // see FileCodeModelCallbackProvider
        call("FileCodeModel_get_CodeElements", projectItemRequest, immutableList(codeElementModel))
    }

    private fun createCodeElementCallbacks() {
        // see CodeElementCallbackProvider
        call("CodeElement_get_Children", codeElementModel, immutableList(codeElementModel))
        call("CodeElement_get_Access", codeElementModel, access)
        call("CodeElement_get_Name", codeElementModel, string.nullable)
        call("CodeElement_get_FullName", codeElementModel, string.nullable)
        call("CodeElement_get_ProjectItem", codeElementModel, projectItemModel.nullable)
        call("CodeElement_get_Parent", codeElementModel, codeElementModel.nullable)

        createCodeTypeCallbacks()
        createCodeFunctionCallbacks()
        createCodeParameterCallbacks()
    }

    private fun createCodeTypeCallbacks() {
        // see CodeTypeCallbackProvider
        call("CodeElement_get_Bases", codeElementModel, immutableList(codeElementModel))
        call("CodeElement_get_Namespace", codeElementModel, codeElementModel.nullable)
    }

    private fun createCodeFunctionCallbacks() {
        // see CodeFunctionCallbackProvider
        call("CodeFunction_get_Type", codeElementModel, codeElementModel.nullable)
    }

    private fun createCodeParameterCallbacks() {
        // see CodeParameterCallbackProvider
        call("CodeParameter_get_Type", codeElementModel, codeElementModel.nullable)
    }
}
