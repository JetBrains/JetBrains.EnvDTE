namespace EnvDTE
{
    public interface _dispTaskListEvents
    {
        void TaskAdded(TaskItem TaskItem);
        void TaskRemoved(TaskItem TaskItem);
        void TaskModified(TaskItem TaskItem, vsTaskListColumn ColumnModified);
        void TaskNavigated(TaskItem TaskItem, ref bool NavigateHandled);
    }
}
