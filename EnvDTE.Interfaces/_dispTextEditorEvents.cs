namespace EnvDTE
{
	public interface _dispTextEditorEvents
	{
		void LineChanged(TextPoint StartPoint, TextPoint EndPoint, int Hint);
	}
}
