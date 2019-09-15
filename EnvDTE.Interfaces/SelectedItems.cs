using System.Collections;

namespace EnvDTE
{
    public interface SelectedItems : IEnumerable
    {
        int Count { get; }
        DTE Parent { get; }
        DTE DTE { get; }
        bool MultiSelect { get; }
        SelectionContainer SelectionContainer { get; }
        SelectedItem Item(object index);
        new IEnumerator GetEnumerator();
    }
}
