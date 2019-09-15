namespace EnvDTE
{
    public class SelectionEventsClass : _SelectionEvents, SelectionEvents, _dispSelectionEvents_Event
    {
        public extern SelectionEventsClass();
        public virtual extern event _dispSelectionEvents_OnChangeEventHandler OnChange;
    }
}
