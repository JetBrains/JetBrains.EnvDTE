using EnvDTE;

namespace EnvDTE80
{
    public interface SolutionFolder
    {
        DTE DTE { get; }
        Project Parent { get; }
        bool Hidden { get; set; }
        Project AddSolutionFolder(string Name);
        Project AddFromFile(string FileName);
        Project AddFromTemplate(string FileName, string Destination, string ProjectName);
    }
}
