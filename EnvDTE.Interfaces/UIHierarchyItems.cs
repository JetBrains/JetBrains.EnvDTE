using System.Collections;

namespace EnvDTE
{
    public interface UIHierarchyItems : IEnumerable
    {
        DTE DTE { get; }
        object Parent { get; }
        int Count { get; }
        bool Expanded { get; set; }
        UIHierarchyItem Item(object index);
        new IEnumerator GetEnumerator();
    }
}
