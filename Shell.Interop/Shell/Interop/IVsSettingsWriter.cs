namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSettingsWriter
    {
        int WriteSettingString(string pszSettingName, string pszSettingValue);

        int WriteSettingLong(string pszSettingName, int lSettingValue);

        int WriteSettingBoolean(string pszSettingName, int fSettingValue);

        int WriteSettingBytes(string pszSettingName, byte[] pSettingValue, int lDataLength);

        int WriteSettingAttribute(
            string pszSettingName,
            string pszAttributeName,
            string pszSettingValue);

        int WriteSettingXml(object pIXMLDOMNode);

        int WriteSettingXmlFromString(string szXML);

        int WriteCategoryVersion(int nMajor, int nMinor, int nBuild, int nRevision);

        int ReportError(string pszError, uint dwErrorType);
    }
}
