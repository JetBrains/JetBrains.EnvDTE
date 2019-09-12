namespace EnvDTE
{
	public interface CodeFunction
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
		vsCMFunction FunctionKind { get; }
		CodeTypeRef Type { get; set; }
		CodeElements Parameters { get; }
		vsCMAccess Access { set; get; }
		bool IsOverloaded { get; }
		bool IsShared { get; set; }
		bool MustImplement { get; set; }
		CodeElements Overloads { get; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		bool CanOverride { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		string get_Prototype(int Flags = 0);
		CodeParameter AddParameter(string Name, object Type, object Position);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
		void RemoveParameter(object Element);
	}
}
