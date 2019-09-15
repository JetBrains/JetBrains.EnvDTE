namespace EnvDTE
{
    public interface IDTCommandTarget
    {
        void QueryStatus(
            string CmdName,
            vsCommandStatusTextWanted NeededText,
            ref vsCommandStatus StatusOption,
            ref object CommandText);

        void Exec(
            string CmdName,
            vsCommandExecOption ExecuteOption,
            ref object VariantIn,
            ref object VariantOut,
            ref bool Handled);
    }
}
