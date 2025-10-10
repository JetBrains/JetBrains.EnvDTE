using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

internal class MappedPropertyInfo<TMapped> : StringPropertyInfo
{
    private readonly IReadOnlyDictionary<TMapped, string> _forwardMap;
    private readonly IReadOnlyDictionary<string, TMapped> _backwardMap;

    public MappedPropertyInfo(
        [NotNull] string visualStudioName,
        [NotNull] string riderName,
        bool isReadOnly,
        [NotNull] IEnumerable<(TMapped, string)> mapPairs)
        : base(visualStudioName, riderName, isReadOnly)
    {
        var mapList = mapPairs.ToList();
        _forwardMap = mapList.ToDictionary(static e => e.Item1, static e => e.Item2);
        _backwardMap = mapList.ToDictionary(static e => e.Item2, static e => e.Item1,
            StringComparer.OrdinalIgnoreCase);
    }

    internal override string GetCanonicalValueOrThrow(object value)
    {
        if (value is not TMapped mappedValue || !_forwardMap.TryGetValue(mappedValue, out var canonicalValue))
            throw new ArgumentException(nameof(value));

        return canonicalValue;
    }

    internal override object ParseValue(string value)
    {
        if (value is null || !_backwardMap.TryGetValue(value, out var mappedValue)) return null;
        return mappedValue;
    }
}
