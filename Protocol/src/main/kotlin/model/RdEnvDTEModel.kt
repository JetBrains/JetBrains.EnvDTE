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

    init {
        createDteCallbacks()
        createSolutionCallbacks()
        createProjectCallbacks()
        createProjectItemCallbacks()
    }

    private fun createDteCallbacks() {
        call("DTE_Name", void, string)
        call("DTE_FileName", void, string)
        call("DTE_CommandLineArgs", void, string)
    }

    private fun createSolutionCallbacks() {
        call("Solution_FileName", void, string)
        call("Solution_Count", void, int)
		call("Solution_Item", int, projectModel)
        call("Solution_get_Projects", void, immutableList(projectModel))
    }

    private fun createProjectCallbacks() {
        call("Project_get_Name", projectModel, string)
        call("Project_set_Name", structdef("Project_set_NameRequest") {
            field("model", projectModel)
            field("newName", string)
        }, void)
        call("Project_get_FileName", projectModel, string)
        call("Project_Delete", projectModel, void)
        call("Project_get_ProjectItems", void, immutableList(projectItemModel))
    }

    private fun createProjectItemCallbacks() {
        call("ProjectItem_get_Name", projectItemModel, string)
        call("ProjectItem_set_Name", structdef("ProjectItem_set_NameRequest") {
            field("model", projectItemModel)
            field("newName", string)
        }, void)
        call("ProjectItem_get_ParentProjectItem", projectItemModel, projectItemModel)
    }
}
