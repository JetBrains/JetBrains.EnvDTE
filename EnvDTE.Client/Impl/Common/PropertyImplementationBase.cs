using System;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Common;

public abstract class PropertyImplementationBase(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] string key)
    : Property
{
    public abstract object Value { get; set; }

    public DTE DTE => dte;
    public Properties Parent => parent;
    public string Name => key;

    #region NotImplemented

    public short NumIndices => throw new NotImplementedException();
    public object Application => throw new NotImplementedException();
    public Properties Collection => throw new NotImplementedException();
    public object Object { get; set; }


    public void let_Value(object lppvReturn) => throw new NotImplementedException();

    public object get_IndexedValue(object Index1, object Index2, object Index3, object Index4) =>
        throw new NotImplementedException();

    public void set_IndexedValue(object Index1, object Index2, object Index3, object Index4, object Val) =>
        throw new NotImplementedException();

    #endregion
}
