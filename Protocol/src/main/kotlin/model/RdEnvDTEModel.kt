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
    val projectModel = structdef {
        field("id", int)
    }

    init {
        call("DTE_Name", void, string)
        call("DTE_FileName", void, string)
        call("DTE_CommandLineArgs", void, string)
        call("Solution_FileName", void, string)
        call("Solution_Count", void, int)
		call("Solution_Item", int, projectModel)
        call("Solution_get_Projects", void, immutableList(projectModel))
        call("Project_get_Name", projectModel, string)
        call("Project_set_Name", structdef("Project_set_NameRequest") {
            field("model", projectModel)
            field("newName", string)
        }, void)
        call("Project_get_FileName", projectModel, string)
    }
}
