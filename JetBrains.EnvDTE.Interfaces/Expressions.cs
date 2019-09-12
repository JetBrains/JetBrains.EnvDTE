using System.Collections;

namespace EnvDTE
{
	public interface Expressions : IEnumerable
	{
		Expression Item(object index);
		new IEnumerator GetEnumerator();
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
	}
}
