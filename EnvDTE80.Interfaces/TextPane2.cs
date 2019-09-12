using EnvDTE;

namespace EnvDTE80
{
	public interface TextPane2 : TextPane
	{
		new DTE DTE { get; }
		new TextPanes Collection { get; }
		new Window Window { get; }
		new int Height { get; }
		new int Width { get; }
		new TextSelection Selection { get; }
		new TextPoint StartPoint { get; }
		IncrementalSearch IncrementalSearch { get; }
		new void Activate();
		new bool IsVisible(TextPoint Point, object PointOrCount);

		new bool TryToShow(
			TextPoint Point,
			vsPaneShowHow How = vsPaneShowHow.vsPaneShowAsIs,
			object PointOrCount = null
		);
	}
}
