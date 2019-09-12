
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeFunction2 : CodeFunction
	{
		new DTE DTE { get; }
		new CodeElements Collection { get; }
		new string this[] { get; set; }
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
		new vsCMFunction FunctionKind { get; }
		new CodeTypeRef Type { get; set; }
		new CodeElements Parameters { get; }
		new vsCMAccess Access { set; get; }
		new bool IsOverloaded { get; }
		new bool IsShared { get; set; }
		new bool MustImplement { get; set; }
		new CodeElements Overloads { get; }
		new CodeElements Attributes { get; }
		new string DocComment { get; set; }
		new string Comment { get; set; }
		new bool CanOverride { get; set; }
		vsCMOverrideKind OverrideKind { get; set; }
		bool IsGeneric { get; }
		new object get_Extender(string ExtenderName);
		new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new string get_Prototype(int Flags = 0);
		new CodeParameter AddParameter(string Name, object Type, object Position);
		new CodeAttribute AddAttribute(string Name, string Value, object Position);
		new void RemoveParameter(object Element);
	}
}
