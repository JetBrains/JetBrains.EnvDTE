
using System.Collections;


namespace EnvDTE
{
	public interface LinkedWindows : IEnumerable
	{
		Window Parent { get; }
		int Count { get; }
		DTE DTE { get; }
		Window Item(object index);
		new IEnumerator GetEnumerator();
		void Remove(Window Window);
		void Add(Window Window);
	}
}
