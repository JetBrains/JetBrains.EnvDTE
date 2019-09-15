using System.Collections;

namespace EnvDTE
{
    public interface CodeElements : IEnumerable
    {
        DTE DTE { get; }
        object Parent { get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
        CodeElement Item(object index);
        void Reserved1(object Element);
        bool CreateUniqueID(string Prefix, string NewName = "0");
    }
}
