namespace EnvDTE
{
    public interface TextPoint
    {
        DTE DTE { get; }
        TextDocument Parent { get; }
        int Line { get; }
        int LineCharOffset { get; }
        int AbsoluteCharOffset { get; }
        int DisplayColumn { get; }
        bool AtEndOfDocument { get; }
        bool AtStartOfDocument { get; }
        bool AtEndOfLine { get; }
        bool AtStartOfLine { get; }
        int LineLength { get; }
        bool EqualTo(TextPoint Point);
        bool LessThan(TextPoint Point);
        bool GreaterThan(TextPoint Point);
        bool TryToShow(vsPaneShowHow How = vsPaneShowHow.vsPaneShowCentered, object PointOrCount = null);
        CodeElement get_CodeElement(vsCMElement Scope);
        EditPoint CreateEditPoint();
    }
}
