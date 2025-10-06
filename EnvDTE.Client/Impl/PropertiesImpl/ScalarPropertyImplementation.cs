using System;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl;

public abstract class ScalarPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] string key)
    : Property
{
    protected readonly DteImplementation DteImplementation = dte;

    public object Application => null;
    public DTE DTE => DteImplementation;
    public Properties Parent => parent;
    public Properties Collection => parent;
    public string Name => key;

    public object Object
    {
        get => this;
        set => throw new NotSupportedException();
    }

    public short NumIndices => 0;

    public abstract object Value { get; set; }

    // Not supported for scalar properties
    public object get_IndexedValue(object index1, object index2, object index3, object index4) =>
        throw new NotSupportedException();

    public void set_IndexedValue(object index1, object index2, object index3, object index4, object val) =>
        throw new NotSupportedException();

    public void let_Value(object lppvReturn) => Value = lppvReturn;
}
