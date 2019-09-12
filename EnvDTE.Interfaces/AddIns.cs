
using System.Collections;


namespace EnvDTE
{
	public interface AddIns : IEnumerable
	{
		object Parent { get; }
		int Count { get; }
		DTE DTE { get; }
		AddIn Item(object index);
		new IEnumerator GetEnumerator();
		void Update();
		AddIn Add(string ProgID, string Description, string Name, bool Connected);
	}
}
