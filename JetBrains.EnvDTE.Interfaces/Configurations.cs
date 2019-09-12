
using System.Collections;


namespace EnvDTE
{
	public interface Configurations : IEnumerable
	{
		DTE DTE { get; }
		object Parent { get; }
		int Count { get; }
		string Name { get; }
		vsConfigurationType Type { get; }
		new IEnumerator GetEnumerator();
		Configuration Item(object index);
	}
}
