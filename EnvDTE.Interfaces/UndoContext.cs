namespace EnvDTE
{
    public interface UndoContext
    {
        DTE DTE { get; }
        DTE Parent { get; }
        bool IsStrict { get; }
        bool IsAborted { get; }
        bool IsOpen { get; }
        void Open(string Name, bool Strict = false);
        void Close();
        void SetAborted();
    }
}
