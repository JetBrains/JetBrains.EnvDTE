
using System.Collections;


namespace EnvDTE
{
	public interface TaskItems : IEnumerable
	{
		DTE DTE { get; }
		TaskList Parent { get; }
		int Count { get; }
		TaskItem Item(object index);

		TaskItem Add(
			string Category,
			string SubCategory,
			string Description,
			vsTaskPriority Priority = vsTaskPriority.vsTaskPriorityMedium,
			object Icon,
			bool Checkable = false,
			string File = "",
			int Line = -1,
			bool CanUserDelete = true,
			bool FlushItem = true);

		new IEnumerator GetEnumerator();
		void ForceItemsToTaskList();
	}
}
