
using System.Collections;


namespace EnvDTE
{
	public interface ContextAttributes : IEnumerable
	{
		DTE DTE { get; }
		object Parent { get; }
		int Count { get; }
		vsContextAttributes Type { get; }
		ContextAttributes HighPriorityAttributes { get; }
		new IEnumerator GetEnumerator();
		ContextAttribute Item(object index);

		ContextAttribute Add(
			string AttributeName,
			string AttributeValue,
			vsContextAttributeType Type);

		void Refresh();
	}
}
