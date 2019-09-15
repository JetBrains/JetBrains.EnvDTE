using EnvDTE;

namespace EnvDTE80
{
    public interface CodeImport : CodeElement
    {
        new DTE DTE { get; }
        new CodeElements Collection { get; }
        new string Name { get; set; }
        new string FullName { get; }
        new ProjectItem ProjectItem { get; }
        new vsCMElement Kind { get; }
        new bool IsCodeType { get; }
        new vsCMInfoLocation InfoLocation { get; }
        new CodeElements Children { get; }
        new string Language { get; }
        new TextPoint StartPoint { get; }
        new TextPoint EndPoint { get; }
        new object ExtenderNames { get; }
        new string ExtenderCATID { get; }
        string Namespace { get; set; }
        string Alias { get; set; }
        object Parent { get; }
        new object get_Extender(string ExtenderName);
        new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
    }
}
