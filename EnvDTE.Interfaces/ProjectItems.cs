using System.Collections;

namespace EnvDTE
{
    public interface ProjectItems : IEnumerable
    {
        object Parent { get; }
        int Count { get; }
        DTE DTE { get; }
        string Kind { get; }
        Project ContainingProject { get; }
        ProjectItem Item(object index);
        new IEnumerator GetEnumerator();
        ProjectItem AddFromFile(string FileName);
        ProjectItem AddFromTemplate(string FileName, string Name);
        ProjectItem AddFromDirectory(string Directory);
        ProjectItem AddFolder(string Name, string Kind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}");
        ProjectItem AddFromFileCopy(string FilePath);
    }
}
