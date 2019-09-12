namespace EnvDTE
{
	public interface CodeProperty
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
		CodeClass Parent { get; }
		CodeTypeRef Type { set; get; }
		CodeFunction Getter { get; set; }
		CodeFunction Setter { get; set; }
		vsCMAccess Access { set; get; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		string get_Prototype(int Flags = 0);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
	}
}
