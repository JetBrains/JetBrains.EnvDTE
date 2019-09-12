namespace EnvDTE
{
	public interface UIHierarchyItem
	{
		DTE DTE { get; }
		UIHierarchyItems Collection { get; }
		string Name { get; }
		UIHierarchyItems UIHierarchyItems { get; }
		object Object { get; }
		bool IsSelected { get; }
		void Select(vsUISelectionType How);
	}
}
