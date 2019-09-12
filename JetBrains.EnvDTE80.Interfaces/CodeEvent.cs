
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeEvent
	{
		DTE DTE { get; }
		CodeElements Collection { get; }
		string this[] { get; set; }
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
		vsCMAccess Access { set; get; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		CodeFunction Adder { get; set; }
		CodeFunction Remover { get; set; }
		CodeFunction Thrower { get; set; }
		bool IsPropertyStyleEvent { get; }
		CodeTypeRef Type { get; set; }
		vsCMOverrideKind OverrideKind { get; set; }
		bool IsShared { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
		string get_Prototype(int Flags = 0);
	}
}
