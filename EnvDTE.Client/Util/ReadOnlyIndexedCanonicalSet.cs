using System.Collections.Generic;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Util;

internal sealed class ReadOnlyIndexedCanonicalSet<TElement>
{
    private readonly List<TElement> _values = new();
    private readonly Dictionary<TElement, int> _set;

    internal int Count => _values.Count;

    internal ReadOnlyIndexedCanonicalSet([NotNull] IEnumerable<TElement> values, IEqualityComparer<TElement> comparer)
    {
        _set = new Dictionary<TElement, int>(comparer);
        foreach (var value in values)
        {
            if (value is null || _set.ContainsKey(value)) continue;
            _set.Add(value, _values.Count);
            _values.Add(value);
        }
    }

    internal bool Contains(TElement value) => _set.ContainsKey(value);

    internal TElement GetAt(int index) => _values[index];

    internal bool TryGetCanonical(TElement value, out TElement canonical)
    {
        if (_set.TryGetValue(value, out var index))
        {
            canonical = _values[index];
            return true;
        }

        canonical = default;
        return false;
    }
}
