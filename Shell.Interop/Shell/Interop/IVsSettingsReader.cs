namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSettingsReader
    {
        int ReadSettingString(string pszSettingName, out string pbstrSettingValue);

        int ReadSettingLong(string pszSettingName, out int plSettingValue);

        int ReadSettingBoolean(string pszSettingName, out int pfSettingValue);

        int ReadSettingBytes(
            string pszSettingName,
            ref byte pSettingValue,
            out int plDataLength,
            int lDataMax);

        int ReadSettingAttribute(
            string pszSettingName,
            string pszAttributeName,
            out string pbstrSettingValue);

        int ReadSettingXml(string pszSettingName, out object ppIXMLDOMNode);

        int ReadSettingXmlAsString(string pszSettingName, out string pbstrXML);

        int ReadCategoryVersion(out int pnMajor, out int pnMinor, out int pnBuild, out int pnRevision);

        int ReadFileVersion(out int pnMajor, out int pnMinor, out int pnBuild, out int pnRevision);

        int ReportError(string pszError, uint dwErrorType);
    }
}
