namespace EnvDTE
{
    public class SelectionEventsClass : _SelectionEvents, SelectionEvents, _dispSelectionEvents_Event
    {
        public SelectionEventsClass(){ }
        public virtual event _dispSelectionEvents_OnChangeEventHandler OnChange;
    }
}
