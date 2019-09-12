namespace EnvDTE
{
	public interface SolutionBuild
	{
		DTE DTE { get; }
		Solution Parent { get; }
		SolutionConfiguration ActiveConfiguration { get; }
		BuildDependencies BuildDependencies { get; }
		vsBuildState BuildState { get; }
		int LastBuildInfo { get; }
		object StartupProjects { set; get; }
		SolutionConfigurations SolutionConfigurations { get; }
		void Build(bool WaitForBuildToFinish = false);
		void Debug();
		void Deploy(bool WaitForDeployToFinish = false);
		void Clean(bool WaitForCleanToFinish = false);
		void Run();

		void BuildProject(
			string SolutionConfiguration,
			string ProjectUniqueName,
			bool WaitForBuildToFinish = false);
	}
}
