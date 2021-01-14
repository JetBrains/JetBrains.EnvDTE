using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsToolboxDataProvider2
    {
        int GetPackageGUID(out Guid pguidPkg);


        int GetUniqueID(out Guid pguidID);


        int GetDisplayName(out string pbstrName);


        int GetItemTipInfo(object pDO, string lpszCurrentName, object pStrings);


        int GetProfileData(object pDO, out string pbstrData);


        int GetItemID(object pDO, out string pbstrID);


        int ReconstituteItem(
            string lpszCurrentName,
            string lpszID,
            string lpszData,
            out object ppDO,
            object[] ptif);
    }
}
