namespace EnvDTE
{
    public interface _dispCommandBarControlEvents
    {
        void Click(object CommandBarControl, ref bool Handled, ref bool CancelDefault);
    }
}
