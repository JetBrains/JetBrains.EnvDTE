
using EnvDTE;


namespace EnvDTE80
{
	public interface SolutionBuild2 : SolutionBuild
	{
		new DTE DTE { get; }
		new Solution Parent { get; }
		new SolutionConfiguration ActiveConfiguration { get; }
		new BuildDependencies BuildDependencies { get; }
		new vsBuildState BuildState { get; }
		new int LastBuildInfo { get; }
		new object StartupProjects { set; get; }
		new SolutionConfigurations SolutionConfigurations { get; }
		int LastPublishInfo { get; }
		vsPublishState PublishState { get; }
		new void Build(bool WaitForBuildToFinish = false);
		new void Debug();
		new void Deploy(bool WaitForDeployToFinish = false);
		new void Clean(bool WaitForCleanToFinish = false);
		new void Run();

		new void BuildProject(
			string SolutionConfiguration,
			string ProjectUniqueName,
			bool WaitForBuildToFinish = false);

		void Publish(bool WaitForPublishToFinish = false);

		void PublishProject(
			string SolutionConfiguration,
			string ProjectUniqueName,
			bool WaitForPublishToFinish = false);

		void DeployProject(
			string SolutionConfiguration,
			string ProjectUniqueName,
			bool WaitForDeployToFinish = false);
	}
}
