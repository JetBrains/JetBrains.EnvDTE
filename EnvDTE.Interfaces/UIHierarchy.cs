namespace EnvDTE
{
    public interface UIHierarchy
    {
        DTE DTE { get; }
        Window Parent { get; }
        UIHierarchyItems UIHierarchyItems { get; }
        object SelectedItems { get; }
        UIHierarchyItem GetItem(string Names);
        void SelectUp(vsUISelectionType How, int Count);
        void SelectDown(vsUISelectionType How, int Count);
        void DoDefaultAction();
    }
}
