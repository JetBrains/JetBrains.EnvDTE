namespace EnvDTE
{
    public interface CodeNamespace
    {
        DTE DTE { get; }
        CodeElements Collection { get; }
        string Name { get; set; }
        string FullName { get; }
        ProjectItem ProjectItem { get; }
        vsCMElement Kind { get; }
        bool IsCodeType { get; }
        vsCMInfoLocation InfoLocation { get; }
        CodeElements Children { get; }
        string Language { get; }
        TextPoint StartPoint { get; }
        TextPoint EndPoint { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        object Parent { get; }
        CodeElements Members { get; }
        string DocComment { get; set; }
        string Comment { get; set; }
        object get_Extender(string ExtenderName);
        TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        CodeNamespace AddNamespace(string Name, object Position);

        CodeClass AddClass(
            string Name,
            object Position,
            object Bases,
            object ImplementedInterfaces,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeInterface AddInterface(
            string Name,
            object Position,
            object Bases,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeStruct AddStruct(
            string Name,
            object Position,
            object Bases,
            object ImplementedInterfaces,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeEnum AddEnum(string Name, object Position, object Bases, vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        CodeDelegate AddDelegate(
            string Name,
            object Type,
            object Position,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        void Remove(object Element);
    }
}
