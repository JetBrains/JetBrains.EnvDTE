namespace EnvDTE
{
    public interface TextPane
    {
        DTE DTE { get; }
        TextPanes Collection { get; }
        Window Window { get; }
        int Height { get; }
        int Width { get; }
        TextSelection Selection { get; }
        TextPoint StartPoint { get; }
        void Activate();
        bool IsVisible(TextPoint Point, object PointOrCount);
        bool TryToShow(TextPoint Point, vsPaneShowHow How = vsPaneShowHow.vsPaneShowAsIs, object PointOrCount = null);
    }
}
