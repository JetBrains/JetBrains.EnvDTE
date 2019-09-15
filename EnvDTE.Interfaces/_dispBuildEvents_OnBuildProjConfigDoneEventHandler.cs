namespace EnvDTE
{
    public delegate void _dispBuildEvents_OnBuildProjConfigDoneEventHandler(
        string Project,
        string ProjectConfig,
        string Platform,
        string SolutionConfig,
        bool Success);
}
