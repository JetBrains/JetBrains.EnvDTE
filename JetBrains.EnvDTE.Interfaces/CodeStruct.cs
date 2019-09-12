namespace EnvDTE
{
	public interface CodeStruct
	{
		DTE DTE { get; }
		CodeElements Collection { get; }
		string Name { get; set; }
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
		CodeNamespace Namespace { get; }
		CodeElements Bases { get; }
		CodeElements Members { get; }
		vsCMAccess Access { set; get; }
		CodeElements Attributes { get; }
		string DocComment { get; set; }
		string Comment { get; set; }
		CodeElements DerivedTypes { get; }
		CodeElements ImplementedInterfaces { get; }
		bool IsAbstract { get; set; }
		object get_Extender(string ExtenderName);
		TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
		CodeElement AddBase(object Base, object Position);
		CodeAttribute AddAttribute(string Name, string Value, object Position);
		void RemoveBase(object Element);
		void RemoveMember(object Element);
		bool get_IsDerivedFrom(string FullName);
		CodeInterface AddImplementedInterface(object Base, object Position);

		CodeFunction AddFunction(
			string Name,
			vsCMFunction Kind,
			object Type,
			object Position = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
			object Location = null);

		CodeVariable AddVariable(
			string Name,
			object Type,
			object Position = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
			object Location = null);

		CodeProperty AddProperty(
			string GetterName,
			string PutterName,
			object Type,
			object Position = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
			object Location = null);

		CodeClass AddClass(
			string Name,
			object Position = null,
			object Bases = null,
			object ImplementedInterfaces = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeStruct AddStruct(
			string Name,
			object Position = null,
			object Bases = null,
			object ImplementedInterfaces = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeEnum AddEnum(
			string Name,
			object Position = null,
			object Bases = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeDelegate AddDelegate(
			string Name,
			object Type,
			object Position = null,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		void RemoveInterface(object Element);
	}
}
