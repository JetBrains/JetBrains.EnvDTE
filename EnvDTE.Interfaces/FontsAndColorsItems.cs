using System.Collections;

namespace EnvDTE
{
    public interface FontsAndColorsItems : IEnumerable
    {
        int Count { get; }
        new IEnumerator GetEnumerator();
        ColorableItems Item(object index);
    }
}
