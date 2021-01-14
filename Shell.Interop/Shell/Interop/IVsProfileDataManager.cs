namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProfileDataManager
    {
        int LastResetPoint(out string pbstrResetFilename);

        int GetSettingsFiles(uint fileLocations, out IVsProfileSettingsFileCollection ppCollection);

        int GetDefaultSettingsLocation(out string pbstrSettingsLocation);

        int GetUniqueExportFileName(uint flags, out string pbstrExportFile);

        int GetSettingsFileExtension(out string pbstrSettingsFileExtension);

        int GetSettingsForExport(out IVsProfileSettingsTree ppSettingsTree);

        int ExportSettings(
            string bstrFilePath,
            IVsProfileSettingsTree pSettingsTree,
            out IVsSettingsErrorInformation ppsettingsErrorInformation);

        int ImportSettings(
            IVsProfileSettingsTree pSettingsTree,
            out IVsSettingsErrorInformation ppsettingsErrorInformation);

        int ResetSettings(
            object pFileInfo,
            out IVsSettingsErrorInformation ppsettingsErrorInformation);

        int ExportAllSettings(
            string bstrFilePath,
            out IVsSettingsErrorInformation ppsettingsErrorInformation);

        int AutoSaveAllSettings(
            out IVsSettingsErrorInformation ppsettingsErrorInformation);

        int CheckUpdateTeamSettings(uint dwFlags);

        int ReportTeamSettingsChanged(uint dwFlags);

        int ShowProfilesUI();
    }
}
