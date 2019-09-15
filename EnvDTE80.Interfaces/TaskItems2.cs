using System.Collections;
using EnvDTE;

namespace EnvDTE80
{
    public interface TaskItems2 : TaskItems
    {
        new DTE DTE { get; }
        new TaskList Parent { get; }
        new int Count { get; }
        new TaskItem Item(object index);

        new TaskItem Add(
            string Category,
            string SubCategory,
            string Description,
            vsTaskPriority Priority = vsTaskPriority.vsTaskPriorityMedium,
            object Icon = null,
            bool Checkable = false,
            string File = "",
            int Line = -1,
            bool CanUserDelete = true,
            bool FlushItem = true);

        new IEnumerator GetEnumerator();
        new void ForceItemsToTaskList();

        TaskItem Add2(
            string Category,
            string SubCategory,
            string Description,
            int Priority = 2,
            object Icon = null,
            bool Checkable = false,
            string File = "",
            int Line = -1,
            bool CanUserDelete = true,
            bool FlushItem = true,
            bool AutoNavigate = false);
    }
}
