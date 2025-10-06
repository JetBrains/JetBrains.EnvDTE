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

    val projectModel = structdef {
        field("id", int)
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

    private val addExistingItemRequest = openstruct {
        field("parentItem", projectItemModel)
        field("path", string)
        field("isDirectory", bool)
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
        call("ProjectItems_addFolder", structdef("ProjectItems_addFolderRequest") {
            field("parentItem", projectItemModel)
            field("name", string)
        }, projectItemModel.nullable)
    }

    private fun createDteCallbacks() {
        // see DteCallbackProvider
        call("DTE_Name", void, string)
        call("DTE_FileName", void, string)
        call("DTE_CommandLineArgs", void, string)
    }

    private fun createSolutionCallbacks() {
        // see SolutionCallbackProvider
        call("Solution_FileName", void, string)
        call("Solution_Count", void, int)
		call("Solution_Item", int, projectModel.nullable)
        call("Solution_get_Projects", void, immutableList(projectModel))
    }

    private fun createProjectCallbacks() {
        // see ProjectCallbackProvider
        call("Project_get_Name", projectModel, string)
        call("Project_set_Name", structdef("Project_set_NameRequest") {
            field("model", projectModel)
            field("newName", string)
        }, void)
        call("Project_get_FileName", projectModel, string)
        call("Project_get_UniqueName", projectModel, string)
        call("Project_get_Kind", projectModel, string)

        call("Project_get_Property", structdef("Project_get_PropertyRequest") {
            field("model", projectModel)
            field("name", string)
        }, string.nullable)
        call("Project_set_Property", structdef("Project_set_PropertyRequest") {
            field("model", projectModel)
            field("name", string)
            field("value", string.nullable)
        }, void)

        call("Project_Delete", projectModel, void)

        // Configuration
        call("Project_get_ConfigurationNames", projectModel, immutableList(string))
        call("Project_get_PlatformNames", projectModel, immutableList(string))
        call("Project_get_ConfigurationCount", projectModel, int)
    }

    private fun createProjectItemCallbacks() {
        // see ProjectItemCallbackProvider
        call("ProjectItem_get_Name", projectItemModel, string)
        call("ProjectItem_set_Name", structdef("ProjectItem_set_NameRequest") {
            field("model", projectItemModel)
            field("newName", string)
        }, void)
        call("ProjectItem_get_Kind", projectItemModel, projectItemKindModel)
        call("ProjectItem_get_ProjectItems", projectItemModel, immutableList(projectItemModel))
        call("ProjectItem_get_Language", projectItemModel, languageModel)
        call("ProjectItem_remove", projectItemModel, void)
        call("ProjectItem_get_SubItemIndex", structdef("ProjectItem_getSubItemIndexRequest") {
            field("item", projectItemModel)
            field("name", string)
        }, int.nullable)
    }

    private fun createFileCodeModelCallbacks() {
      // see FileCodeModelCallbackProvider
      call("FileCodeModel_get_CodeElements", projectItemModel, immutableList(codeElementModel))
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
