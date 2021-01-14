namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUserSettings
    {
        int ExportSettings(string pszCategoryGUID, IVsSettingsWriter pSettings);


        int ImportSettings(
            string pszCategoryGUID,
            IVsSettingsReader pSettings,
            uint flags,
            ref int pfRestartRequired);
    }
}
