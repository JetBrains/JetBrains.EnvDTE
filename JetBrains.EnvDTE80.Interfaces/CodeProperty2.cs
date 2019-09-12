
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeProperty2 : CodeProperty
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
		new CodeClass Parent { get; }
		new CodeTypeRef Type { set; get; }
		new CodeFunction Getter { get; set; }
		new CodeFunction Setter { get; set; }
		new vsCMAccess Access { set; get; }
		new CodeElements Attributes { get; }
		new string DocComment { get; set; }
		new string Comment { get; set; }
		CodeElements Parameters { get; }
		bool IsGeneric { get; }
		vsCMOverrideKind OverrideKind { get; set; }
		bool IsShared { get; set; }
		bool IsDefault { get; set; }
		CodeElement Parent2 { get; }
		vsCMPropertyKind ReadWrite { get; }
		new object get_Extender(string ExtenderName);
		new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new string get_Prototype(int Flags = 0);
		new CodeAttribute AddAttribute(string Name, string Value, object Position);
		CodeParameter AddParameter(string Name, object Type, object Position);
		void RemoveParameter(object Element);
	}
}
