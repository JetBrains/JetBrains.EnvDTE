namespace EnvDTE
{
    public interface Globals
    {
        DTE DTE { get; }
        object Parent { get; }
        object this[string VariableName] { get; set; }
        object VariableNames { get; }
        void set_VariablePersists(string VariableName, bool pVal);
        bool get_VariablePersists(string VariableName);
        bool get_VariableExists(string Name);
    }
}
