
using System.Collections;


namespace EnvDTE
{
	public interface Projects : IEnumerable
	{
		DTE Parent { get; }
		int Count { get; }
		DTE DTE { get; }
		Properties Properties { get; }
		string Kind { get; }
		Project Item(object index);
		new IEnumerator GetEnumerator();
	}
}
