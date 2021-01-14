using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsRefactorNotify
    {
        int OnBeforeGlobalSymbolRenamed(
            object pHier,
            uint itemid,
            uint cRQNames,
            string[] rglpszRQName,
            string lpszNewName,
            out Array prgAdditionalCheckoutVSITEMIDs);

        int OnGlobalSymbolRenamed(
            object pHier,
            uint itemid,
            uint cRQNames,
            string[] rglpszRQName,
            string lpszNewName);

        int OnBeforeReorderParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes,
            out Array prgAdditionalCheckoutVSITEMIDs);

        int OnReorderParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes);

        int OnBeforeRemoveParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes,
            out Array prgAdditionalCheckoutVSITEMIDs);

        int OnRemoveParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes);

        int OnBeforeAddParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParams,
            uint[] rgszParamIndexes,
            string[] rgszRQTypeNames,
            string[] rgszParamNames,
            out Array prgAdditionalCheckoutVSITEMIDs);

        int OnAddParams(
            object pHier,
            uint itemid,
            string lpszRQName,
            uint cParams,
            uint[] rgszParamIndexes,
            string[] rgszRQTypeNames,
            string[] rgszParamNames);
    }
}
