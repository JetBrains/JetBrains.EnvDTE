namespace EnvDTE
{
	public interface VirtualPoint : TextPoint
	{
		new DTE DTE { get; }
		new TextDocument Parent { get; }
		new int Line { get; }
		new int LineCharOffset { get; }
		new int AbsoluteCharOffset { get; }
		new int DisplayColumn { get; }
		new bool AtEndOfDocument { get; }
		new bool AtStartOfDocument { get; }
		new bool AtEndOfLine { get; }
		new bool AtStartOfLine { get; }
		new int LineLength { get; }
		int VirtualCharOffset { get; }
		int VirtualDisplayColumn { get; }
		new bool EqualTo(TextPoint Point);
		new bool LessThan(TextPoint Point);
		new bool GreaterThan(TextPoint Point);
		new bool TryToShow(vsPaneShowHow How = vsPaneShowHow.vsPaneShowCentered, object PointOrCount = null);
		new CodeElement get_CodeElement(vsCMElement Scope);
		new EditPoint CreateEditPoint();
	}
}
