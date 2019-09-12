namespace EnvDTE
{
	public interface SolutionConfiguration
	{
		DTE DTE { get; }
		SolutionConfigurations Collection { get; }
		string this[] { get; }
		SolutionContexts SolutionContexts { get; }
		void Delete();
		void Activate();
	}
}
