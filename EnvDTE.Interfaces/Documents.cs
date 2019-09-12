
using System.Collections;


namespace EnvDTE
{
	public interface Documents : IEnumerable
	{
		DTE DTE { get; }
		DTE Parent { get; }
		int Count { get; }
		new IEnumerator GetEnumerator();
		Document Item(object index);
		Document Add(string Kind);
		void CloseAll(vsSaveChanges Save = vsSaveChanges.vsSaveChangesPrompt);
		void SaveAll();
		Document Open(string PathName, string Kind = "Auto", bool ReadOnly = false);
	}
}
