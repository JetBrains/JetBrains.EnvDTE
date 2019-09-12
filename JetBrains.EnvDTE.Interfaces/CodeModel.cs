namespace EnvDTE
{
	public interface CodeModel
	{
		DTE DTE { get; }
		Project Parent { get; }
		string Language { get; }
		CodeElements CodeElements { get; }
		bool IsCaseSensitive { get; }
		CodeType CodeTypeFromFullName(string Name);
		CodeNamespace AddNamespace(string Name, object Location, object Position);

		CodeClass AddClass(
			string Name,
			object Location,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeInterface AddInterface(
			string Name,
			object Location,
			object Position,
			object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeFunction AddFunction(
			string Name,
			object Location,
			vsCMFunction Kind,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeVariable AddVariable(
			string Name,
			object Location,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeStruct AddStruct(
			string Name,
			object Location,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeEnum AddEnum(
			string Name,
			object Location,
			object Position,
			object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeDelegate AddDelegate(
			string Name,
			object Location,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		CodeAttribute AddAttribute(
			string Name,
			object Location,
			string Value,
			object Position);

		void Remove(object Element);
		bool IsValidID(string Name);
		CodeTypeRef CreateCodeTypeRef(object Type);
	}
}
