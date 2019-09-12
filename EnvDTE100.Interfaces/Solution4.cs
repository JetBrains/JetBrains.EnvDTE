
using System.Collections;
using EnvDTE;
using EnvDTE90;


namespace EnvDTE100
{
	public interface Solution4 : Solution3
	{
		new DTE DTE { get; }
		new DTE Parent { get; }
		new int Count { get; }
		new string FileName { get; }
		new Properties Properties { get; }
		new bool IsDirty { get; set; }
		new string FullName { get; }
		new bool Saved { get; set; }
		new Globals Globals { get; }
		new AddIns AddIns { get; }
		new object ExtenderNames { get; }
		new string ExtenderCATID { get; }
		new bool IsOpen { get; }
		new SolutionBuild SolutionBuild { get; }
		new Projects Projects { get; }
		new Project Item(object index);
		new IEnumerator GetEnumerator();
		new void SaveAs(string FileName);

		new Project AddFromTemplate(
			string FileName,
			string Destination,
			string ProjectName,
			bool Exclusive = true);

		new Project AddFromFile(string FileName, bool Exclusive = true);
		new void Open(string FileName);
		new void Close(bool SaveFirst = true);
		new void Remove(Project proj);
		new string get_TemplatePath(string ProjectType);
		new object get_Extender(string ExtenderName);
		new void Create(string Destination, string Name);
		new ProjectItem FindProjectItem(string FileName);
		new string ProjectItemsTemplatePath(string ProjectKind);
		new Project AddSolutionFolder(string Name);
		new string GetProjectTemplate(string TemplateName, string Language);
		new string GetProjectItemTemplate(string TemplateName, string Language);
		new Templates GetProjectItemTemplates(string Language, string CustomDataSignature);

		Project AddFromTemplateEx(
			string FileName,
			string Destination,
			string ProjectName,
			string SolutionName,
			bool Exclusive = true,
			uint Options = 0);
	}
}
