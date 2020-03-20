package model

import com.jetbrains.rd.generator.nova.csharp.CSharp50Generator
import com.jetbrains.rd.generator.nova.setting
import com.jetbrains.rd.generator.nova.*
import com.jetbrains.rd.generator.nova.PredefinedType.*
import com.jetbrains.rider.model.nova.ide.*

object DteRoot : Root() {
    override val isLibrary = false
    init {
        setting(CSharp50Generator.ClassAttributes, emptyArray())
    }
}

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

    // #region AST

    val codeElementModel = basestruct {
      field("Name", string)
    }

    val methodModel = structdef extends codeElementModel {
    }

    val propertyModel = structdef extends codeElementModel {
    }

    val typeKind = enum {
      +"Interface"
      +"Class"
      +"Struct"
    }

    val typeModel = structdef extends codeElementModel {
      field("Kind", typeKind)
      field("Methods", immutableList(methodModel))
      field("Properties", immutableList(propertyModel))
      field("NestedTypes", immutableList(this))
      call("BaseTypes", void, immutableList(this))
    }

    val namespaceModel = structdef extends codeElementModel {
      field("Types", immutableList(typeModel))
    }

    // #endregion AST

    init {
        createDteCallbacks()
        createSolutionCallbacks()
        createProjectCallbacks()
        createProjectItemCallbacks()
        createFileCodeModelCallbacks()
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
        call("Project_Delete", projectModel, void)
        call("Project_get_ProjectItems", projectModel, immutableList(projectItemModel))
    }

    private fun createProjectItemCallbacks() {
        // see ProjectItemCallbackProvider
        call("ProjectItem_get_Name", projectItemModel, string)
        call("ProjectItem_set_Name", structdef("ProjectItem_set_NameRequest") {
            field("model", projectItemModel)
            field("newName", string)
        }, void)
        call("ProjectItem_get_Kind", projectItemModel, projectItemKindModel)
    }

    private fun createFileCodeModelCallbacks() {
      // see FileCodeModelCallbackProvider
      call("FileCodeModel_get_Language", projectItemModel, languageModel)
      call("FileCodeModel_get_Namespaces", projectItemModel, immutableList(namespaceModel))
      call("FileCodeModel_get_Types", projectItemModel, immutableList(typeModel))
    }
}
