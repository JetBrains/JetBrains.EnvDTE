using EnvDTE;

namespace EnvDTE80
{
    public interface CodeVariable2 : CodeVariable
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
        new object Parent { get; }
        new object InitExpression { get; set; }
        new CodeTypeRef Type { set; get; }
        new vsCMAccess Access { set; get; }
        new bool IsConstant { get; set; }
        new CodeElements Attributes { get; }
        new string DocComment { get; set; }
        new string Comment { get; set; }
        new bool IsShared { get; set; }
        vsCMConstKind ConstKind { get; set; }
        bool IsGeneric { get; }
        new object get_Extender(string ExtenderName);
        new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        new string get_Prototype(int Flags = 0);
        new CodeAttribute AddAttribute(string Name, string Value, object Position);
    }
}
