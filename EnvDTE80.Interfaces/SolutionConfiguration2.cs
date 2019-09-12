
using EnvDTE;


namespace EnvDTE80
{
	public interface SolutionConfiguration2 : SolutionConfiguration
	{
		new DTE DTE { get; }
		new SolutionConfigurations Collection { get; }
		new string Name { get; }
		new SolutionContexts SolutionContexts { get; }
		string PlatformName { get; }
		new void Delete();
		new void Activate();
	}
}
