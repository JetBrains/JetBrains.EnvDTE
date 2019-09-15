namespace EnvDTE
{
    public delegate void _dispTextEditorEvents_LineChangedEventHandler(
        TextPoint StartPoint,
        TextPoint EndPoint,
        int Hint);
}
