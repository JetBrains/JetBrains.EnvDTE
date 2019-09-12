
using EnvDTE;


namespace EnvDTE80
{
	public interface CodeModel2 : CodeModel
	{
		new DTE DTE { get; }
		new Project Parent { get; }
		new string Language { get; }
		new CodeElements CodeElements { get; }
		new bool IsCaseSensitive { get; }
		new CodeType CodeTypeFromFullName(string Name);
		new CodeNamespace AddNamespace(string Name, object Location, object Position);

		new CodeClass AddClass(
			string Name,
			object Location,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeInterface AddInterface(
			string Name,
			object Location,
			object Position,
			object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeFunction AddFunction(
			string Name,
			object Location,
			vsCMFunction Kind,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeVariable AddVariable(
			string Name,
			object Location,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeStruct AddStruct(
			string Name,
			object Location,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeEnum AddEnum(
			string Name,
			object Location,
			object Position,
			object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeDelegate AddDelegate(
			string Name,
			object Location,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeAttribute AddAttribute(
			string Name,
			object Location,
			string Value,
			object Position);

		new void Remove(object Element);
		new bool IsValidID(string Name);
		new CodeTypeRef CreateCodeTypeRef(object Type);
		void Synchronize();
		string DotNetNameFromLanguageSpecific(string LanguageName);
		string LanguageSpecificNameFromDotNet(string DotNETName);
		CodeElement ElementFromID(string ID);
	}
}
