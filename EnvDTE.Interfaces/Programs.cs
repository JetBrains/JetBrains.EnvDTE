
using System.Collections;


namespace EnvDTE
{
	public interface Programs : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		Program Item(object index);
		new IEnumerator GetEnumerator();
	}
}
