namespace EnvDTE
{
    public interface FileCodeModel
    {
        DTE DTE { get; }
        ProjectItem Parent { get; }
        string Language { get; }
        CodeElements CodeElements { get; }
        CodeElement CodeElementFromPoint(TextPoint Point, vsCMElement Scope);
        CodeNamespace AddNamespace(string Name, object Position = null);

        CodeClass AddClass(
            string Name,
            object Position = null,
            object Bases = null,
            object ImplementedInterfaces = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeInterface AddInterface(
            string Name,
            object Position = null,
            object Bases = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeFunction AddFunction(
            string Name,
            vsCMFunction Kind,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeVariable AddVariable(
            string Name,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeAttribute AddAttribute(string Name, string Value, object Position = null);

        CodeStruct AddStruct(
            string Name,
            object Position = null,
            object Bases = null,
            object ImplementedInterfaces = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeEnum AddEnum(string Name, object Position, object Bases, vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeDelegate AddDelegate(
            string Name,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        void Remove(object Element);
    }
}
