namespace EnvDTE
{
    public interface StatusBar
    {
        DTE DTE { get; }
        DTE Parent { get; }
        string Text { set; get; }
        void Clear();
        void Animate(bool On, object AnimationType);
        void Progress(bool InProgress, string Label = "", int AmountCompleted = 0, int Total = 0);
        void SetXYWidthHeight(int X, int Y, int Width, int Height);
        void SetLineColumnCharacter(int Line, int Column, int Character);
        void Highlight(bool Highlight);
        bool ShowTextUpdates(bool TextUpdates);
    }
}
