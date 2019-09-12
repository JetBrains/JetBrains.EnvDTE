namespace EnvDTE
{
	public interface UIHierarchyItem
	{
		DTE DTE { get; }
		UIHierarchyItems Collection { get; }
		string this[] { get; }
		UIHierarchyItems UIHierarchyItems { get; }
		object Object { get; }
		bool IsSelected { get; }
		void Select(vsUISelectionType How);
	}
}
