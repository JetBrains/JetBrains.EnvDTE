
using System.Collections;


namespace EnvDTE
{
	public interface Threads : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		Thread Item(object index);
		new IEnumerator GetEnumerator();
	}
}
