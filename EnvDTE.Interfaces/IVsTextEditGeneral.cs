namespace EnvDTE
{
	public interface IVsTextEditGeneral
	{
		bool SelectionMargin { set; get; }
		bool GoToAnchorAfterEscape { set; get; }
		bool DragNDropTextEditing { set; get; }
		bool UndoCaretActions { set; get; }
		bool MarginIndicatorBar { set; get; }
		bool HorizontalScrollBar { set; get; }
		bool VerticalScrollBar { set; get; }
		bool AutoDelimiterHighlighting { set; get; }
	}
}
