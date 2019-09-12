
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeAttributeArgument
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
		string Value { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		void Delete();
	}
}
