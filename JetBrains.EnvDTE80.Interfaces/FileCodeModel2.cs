
using EnvDTE;


namespace EnvDTE80
{
	public interface FileCodeModel2 : FileCodeModel
	{
		new DTE DTE { get; }
		new ProjectItem Parent { get; }
		new string Language { get; }
		new CodeElements CodeElements { get; }
		vsCMParseStatus ParseStatus { get; }
		bool IsBatchOpen { get; }
		new CodeElement CodeElementFromPoint(TextPoint Point, vsCMElement Scope);
		new CodeNamespace AddNamespace(string Name, object Position);

		new CodeClass AddClass(
			string Name,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeInterface AddInterface(
			string Name,
			object Position,
			object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeFunction AddFunction(
			string Name,
			vsCMFunction Kind,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeVariable AddVariable(
			string Name,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeAttribute AddAttribute(string Name, string Value, object Position);

		new CodeStruct AddStruct(
			string Name,
			object Position,
			object Bases,
			object ImplementedInterfaces,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeEnum AddEnum(string Name, object Position, object Bases,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new CodeDelegate AddDelegate(
			string Name,
			object Type,
			object Position,
			vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

		new void Remove(object Element);
		void Synchronize();
		CodeImport AddImport(string Name, object Position, string Alias = "");
		void BeginBatch();
		void EndBatch();
		CodeElement ElementFromID(string ID);
	}
}
