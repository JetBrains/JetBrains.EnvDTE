namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsHierarchyDeleteHandler2
    {
        int ShowSpecificDeleteRemoveMessage(
            uint dwDelItemOps,
            uint cDelItems,
            uint[] rgDelItems,
            out int pfShowStandardMessage,
            out uint pdwDelItemOp);

        int ShowMultiSelDeleteOrRemoveMessage(
            uint dwDelItemOp,
            uint cDelItems,
            uint[] rgDelItems,
            out int pfCancelOperation);
    }
}
