namespace EnvDTE
{
	public interface _EnvironmentProjectsAndSolution
	{
		vsSaveChanges OnRunOrPreview { set; get; }
		string ProjectsLocation { set; get; }
		bool ShowOutputWindowBeforeBuild { set; get; }
		bool ShowTaskListAfterBuild { set; get; }
	}
}
