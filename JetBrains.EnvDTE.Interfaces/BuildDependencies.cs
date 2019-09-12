
using System.Collections;


namespace EnvDTE
{
	public interface BuildDependencies : IEnumerable
	{
		DTE DTE { get; }
		SolutionBuild Parent { get; }
		int Count { get; }
		new IEnumerator GetEnumerator();
		BuildDependency Item(object index);
	}
}
