namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsHierarchyRefactorNotify
    {
        int OnBeforeGlobalSymbolRenamed(
            uint cItemsAffected,
            uint[] rgItemsAffected,
            uint cRQNames,
            string[] rglpszRQName,
            string lpszNewName,
            int promptContinueOnFail);

        int OnGlobalSymbolRenamed(
            uint cItemsAffected,
            uint[] rgItemsAffected,
            uint cRQNames,
            string[] rglpszRQName,
            string lpszNewName);

        int OnBeforeReorderParams(
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes,
            int promptContinueOnFail);

        int OnReorderParams(
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes);

        int OnBeforeRemoveParams(
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes,
            int promptContinueOnFail);

        int OnRemoveParams(
            uint itemid,
            string lpszRQName,
            uint cParamIndexes,
            uint[] rgParamIndexes);

        int OnBeforeAddParams(
            uint itemid,
            string lpszRQName,
            uint cParams,
            uint[] rgszParamIndexes,
            string[] rgszRQTypeNames,
            string[] rgszParamNames,
            int promptContinueOnFail);

        int OnAddParams(
            uint itemid,
            string lpszRQName,
            uint cParams,
            uint[] rgszParamIndexes,
            string[] rgszRQTypeNames,
            string[] rgszParamNames);
    }
}
