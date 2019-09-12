namespace EnvDTE
{
	public interface CodeVariable
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
		object InitExpression { get; set; }
		CodeTypeRef Type { set; get; }
		vsCMAccess Access { set; get; }
		bool IsConstant { get; set; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		bool IsShared { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		string get_Prototype(int Flags = 0);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
	}
}
