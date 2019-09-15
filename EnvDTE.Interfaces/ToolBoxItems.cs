using System.Collections;

namespace EnvDTE
{
    public interface ToolBoxItems : IEnumerable
    {
        ToolBoxTab Parent { get; }
        DTE DTE { get; }
        int Count { get; }
        ToolBoxItem SelectedItem { get; }
        new IEnumerator GetEnumerator();
        ToolBoxItem Item(object index);

        ToolBoxItem Add(string Name, object Data,
            vsToolBoxItemFormat Format = vsToolBoxItemFormat.vsToolBoxItemFormatText);
    }
}
