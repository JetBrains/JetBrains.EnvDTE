using System.Collections;

namespace EnvDTE
{
    public interface TextRanges : IEnumerable
    {
        DTE DTE { get; }
        TextDocument Parent { get; }
        int Count { get; }
        TextRange Item(object index);
        new IEnumerator GetEnumerator();
    }
}
