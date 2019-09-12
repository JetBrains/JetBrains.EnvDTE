
using System.Collections;
using EnvDTE;


namespace EnvDTE90
{
	public interface ExceptionGroups : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		ExceptionSettings Item(object Index);
		new IEnumerator GetEnumerator();
		void ResetAll();
	}
}
