
using System.Collections;


namespace EnvDTE
{
	public interface TextPanes : IEnumerable
	{
		DTE DTE { get; }
		TextWindow Parent { get; }
		int Count { get; }
		TextPane Item(object index);
		new IEnumerator GetEnumerator();
	}
}
