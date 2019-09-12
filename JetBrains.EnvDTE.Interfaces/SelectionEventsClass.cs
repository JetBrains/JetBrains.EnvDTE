namespace EnvDTE
{
	public class SelectionEventsClass : _SelectionEvents, SelectionEvents, _dispSelectionEvents_Event
	{
		public extern SelectionEventsClass();
		public virtual extern event _dispSelectionEvents_OnChangeEventHandler OnChange;
		public virtual extern void add_OnChange(_dispSelectionEvents_OnChangeEventHandler A_1);
		public virtual extern void remove_OnChange(_dispSelectionEvents_OnChangeEventHandler A_1);
	}
}
