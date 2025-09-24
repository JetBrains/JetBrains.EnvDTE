using System;
using System.Collections;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Common;

public class PropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] Func<object, PropertyImplementationBase> getItem)
    : Properties
{
    public object Parent => parent;
    public DTE DTE => dte;

    public Property Item(object index) => getItem(index);

    #region NotImplemented

    public object Application => throw new NotImplementedException();
    public int Count => throw new NotImplementedException();

    IEnumerator Properties.GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    #endregion
}
