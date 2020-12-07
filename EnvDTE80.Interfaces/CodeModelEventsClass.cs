namespace EnvDTE80
{
    public class CodeModelEventsClass : _CodeModelEvents, CodeModelEvents, _dispCodeModelEvents_Event
    {
        public  CodeModelEventsClass(){}
        public virtual event _dispCodeModelEvents_ElementAddedEventHandler ElementAdded;
        public virtual event _dispCodeModelEvents_ElementChangedEventHandler ElementChanged;
        public virtual event _dispCodeModelEvents_ElementDeletedEventHandler ElementDeleted;
    }
}
