namespace EnvDTE
{
	public interface ProjectItem
	{
		bool IsDirty { get; set; }
		short FileCount { get; }
		string Name { get; set; }
		ProjectItems Collection { get; }
		Properties Properties { get; }
		DTE DTE { get; }
		string Kind { get; }
		ProjectItems ProjectItems { get; }
		object Object { get; }
		object ExtenderNames { get; }
		string ExtenderCATID { get; }
		bool Saved { get; set; }
		ConfigurationManager ConfigurationManager { get; }
		FileCodeModel FileCodeModel { get; }
		Document Document { get; }
		Project SubProject { get; }
		Project ContainingProject { get; }
		string get_FileNames(short index);
		bool SaveAs(string NewFileName);
		bool get_IsOpen(string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}");
		Window Open(string ViewKind = "{00000000-0000-0000-0000-000000000000}");
		void Remove();
		void ExpandView();
		object get_Extender(string ExtenderName);
		void Save(string FileName = "");
		void Delete();
	}
}
