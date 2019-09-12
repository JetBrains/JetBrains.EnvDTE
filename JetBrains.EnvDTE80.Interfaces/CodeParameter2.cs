
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeParameter2 : CodeParameter
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
		new CodeElement Parent { get; }
		new CodeTypeRef Type { set; get; }
		new CodeElements Attributes { get; }
		new string DocComment { get; set; }
		vsCMParameterKind ParameterKind { get; set; }
		string DefaultValue { get; set; }
		new object get_Extender(string ExtenderName);
		new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		new CodeAttribute AddAttribute(string Name, string Value, object Position);
	}
}
