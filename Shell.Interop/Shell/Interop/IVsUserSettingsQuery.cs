namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUserSettingsQuery
    {
        int NeedExport(string szCategoryGUID, out int pfNeedExport);
    }
}
