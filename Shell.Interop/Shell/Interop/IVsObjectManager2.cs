using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsObjectManager2
    {
        int RegisterLibrary(IVsLibrary2 pLib, out uint pdwCookie);

        int RegisterSimpleLibrary(object pLib, out uint pdwCookie);

        int UnregisterLibrary(uint dwCookie);

        int EnumLibraries(out IVsEnumLibraries2 ppEnum);

        int FindLibrary(ref Guid guidLibrary, out IVsLibrary2 ppLib);

        int GetListAndIndex(
            IVsNavInfo pNavInfo,
            uint dwFlags,
            out IVsObjectList2 ppList,
            out uint pIndex);

        int ParseDataObject(object pIDataObject, out IVsSelectedSymbols ppSymbols);

        int CreateSimpleBrowseComponentSet(
            uint Type,
            Guid[] rgguidLibs,
            uint ulcLibs,
            out IVsSimpleBrowseComponentSet ppSet);

        int CreateProjectReferenceSet(object pProject, out IVsSimpleBrowseComponentSet ppSet);

        int CreateCombinedBrowseComponentSet(out object ppCombinedSet);
    }
}
