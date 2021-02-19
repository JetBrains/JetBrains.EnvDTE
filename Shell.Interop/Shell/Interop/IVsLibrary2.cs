using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsLibrary2
    {
        int GetSupportedCategoryFields2(int Category, out uint pgrfCatField);

        int GetList2(
            uint ListType,
            uint flags,
            VSOBSEARCHCRITERIA2[] pobSrch,
            out IVsObjectList2 ppIVsObjectList2);

        int GetLibList(object lptType, out object ppList);

        int GetLibFlags2(out uint pgrfFlags);

        int UpdateCounter(out uint pCurUpdate);

        int GetGuid(out IntPtr ppguidLib);

        int GetSeparatorString(IntPtr pszSeparator);

        int LoadState(object pIStream, object lptType);

        int SaveState(object pIStream, object lptType);

        int GetBrowseContainersForHierarchy(
            object pHierarchy,
            uint celt,
            object[] rgBrowseContainers,
            uint[] pcActual);

        int AddBrowseContainer(
            object[] pcdComponent,
            ref uint pgrfOptions,
            string[] pbstrComponentAdded);

        int RemoveBrowseContainer(uint dwReserved, string pszLibName);

        int CreateNavInfo(
            object[] rgSymbolNodes,
            uint ulcNodes,
            out IVsNavInfo ppNavInfo);
    }
}
