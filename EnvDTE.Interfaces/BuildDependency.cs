namespace EnvDTE
{
    public interface BuildDependency
    {
        DTE DTE { get; }
        BuildDependencies Collection { get; }
        Project Project { get; }
        object RequiredProjects { get; }
        void AddProject(string ProjectUniqueName);
        void RemoveProject(string ProjectUniqueName);
        void RemoveAllProjects();
    }
}
