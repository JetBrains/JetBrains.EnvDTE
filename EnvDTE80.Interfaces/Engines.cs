
using System.Collections;
using EnvDTE;


namespace EnvDTE80
{
	public interface Engines : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		Engine Item(object index);
		new IEnumerator GetEnumerator();
	}
}
