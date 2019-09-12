namespace EnvDTE
{
	public class TextEditorEventsClass : _TextEditorEvents, TextEditorEvents, _dispTextEditorEvents_Event
	{
		public extern TextEditorEventsClass();
		public virtual extern event _dispTextEditorEvents_LineChangedEventHandler LineChanged;
		public virtual extern void add_LineChanged(_dispTextEditorEvents_LineChangedEventHandler A_1);
		public virtual extern void remove_LineChanged(_dispTextEditorEvents_LineChangedEventHandler A_1);
	}
}
