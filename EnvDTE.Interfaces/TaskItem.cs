namespace EnvDTE
{
    public interface TaskItem
    {
        DTE DTE { get; }
        TaskItems Collection { get; }
        string Category { get; }
        string SubCategory { get; }
        vsTaskPriority Priority { get; set; }
        string Description { get; set; }
        string FileName { get; set; }
        int Line { get; set; }
        bool Displayed { get; }
        bool Checked { get; set; }
        bool get_IsSettable(vsTaskListColumn Column);
        void Navigate();
        void Delete();
        void Select();
    }
}
