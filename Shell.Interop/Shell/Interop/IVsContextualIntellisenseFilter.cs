namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsContextualIntellisenseFilter
    {
        int Initialize(object pHierarchy);

        int IsTypeVisible(string szTypeName, out int pfVisible);

        int IsMemberVisible(string szMemberSignature, out int pfVisible);

        int Close();
    }
}
