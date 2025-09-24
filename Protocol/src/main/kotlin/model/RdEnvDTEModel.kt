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

    val Project_get_PropertyRequest = structdef {
        field("model", projectModel)
        field("name", string)
    }

    init {
        createDteCallbacks()
        createSolutionCallbacks()
        createProjectCallbacks()
        createProjectItemCallbacks()
        createFileCodeModelCallbacks()
        createCodeElementCallbacks()
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
		call("Solution_Item", int, projectModel)
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

        call("Project_get_Property", Project_get_PropertyRequest, string.nullable)
        call("Project_isValid_Property", Project_get_PropertyRequest, bool)
        call("Project_set_Property", structdef("Project_set_PropertyRequest") {
            field("model", projectModel)
            field("name", string)
            field("value", string.nullable)
        }, void)

        call("Project_Delete", projectModel, void)
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
