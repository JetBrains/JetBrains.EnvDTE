using System.Collections;

namespace EnvDTE
{
    public interface SelectionContainer : IEnumerable
    {
        int Count { get; }
        SelectedItems Parent { get; }
        DTE DTE { get; }
        object Item(object index);
        new IEnumerator GetEnumerator();
    }
}
