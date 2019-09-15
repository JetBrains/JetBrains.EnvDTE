namespace EnvDTE
{
    public interface SolutionContext
    {
        DTE DTE { get; }
        SolutionContexts Collection { get; }
        string ProjectName { get; }
        string ConfigurationName { get; set; }
        string PlatformName { get; }
        bool ShouldBuild { get; set; }
        bool ShouldDeploy { get; set; }
    }
}
