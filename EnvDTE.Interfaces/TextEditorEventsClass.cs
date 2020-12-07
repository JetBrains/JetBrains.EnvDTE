namespace EnvDTE
{
    public class TextEditorEventsClass : _TextEditorEvents, TextEditorEvents, _dispTextEditorEvents_Event
    {
        public TextEditorEventsClass(){ }
        public virtual event _dispTextEditorEvents_LineChangedEventHandler LineChanged;
    }
}
