namespace EnvDTE
{
	public interface SourceControl
	{
		DTE DTE { get; }
		DTE Parent { get; }
		bool IsItemUnderSCC(string ItemName);
		bool IsItemCheckedOut(string ItemName);
		bool CheckOutItem(string ItemName);
		bool CheckOutItems(ref object[] ItemNames);
		void ExcludeItem(string ProjectFile, string ItemName);
		void ExcludeItems(string ProjectFile, ref object[] ItemNames);
	}
}
