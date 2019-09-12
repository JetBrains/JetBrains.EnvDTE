namespace EnvDTE
{
	public interface _dispBuildEvents
	{
		void OnBuildBegin(vsBuildScope Scope, vsBuildAction Action);
		void OnBuildDone(vsBuildScope Scope, vsBuildAction Action);

		void OnBuildProjConfigBegin(
			string Project,
			string ProjectConfig,
			string Platform,
			string SolutionConfig);

		void OnBuildProjConfigDone(
			string Project,
			string ProjectConfig,
			string Platform,
			string SolutionConfig,
			bool Success);
	}
}
