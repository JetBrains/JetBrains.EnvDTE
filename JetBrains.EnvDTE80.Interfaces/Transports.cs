
using System.Collections;
using EnvDTE;


namespace EnvDTE80
{
	public interface Transports : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		Transport Item(object index);
		new IEnumerator GetEnumerator();
	}
}
