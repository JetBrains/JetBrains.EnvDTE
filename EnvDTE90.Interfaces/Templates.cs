
using System.Collections;


namespace EnvDTE90
{
	public interface Templates : IEnumerable
	{
		Template this[int Index] { get; }
		int Count { get; }
		new IEnumerator GetEnumerator();
	}
}
