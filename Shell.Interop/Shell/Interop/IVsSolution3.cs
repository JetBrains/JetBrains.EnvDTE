namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSolution3
    {
        int CreateNewProjectViaDlgEx(
            string pszDlgTitle,
            string pszTemplateDir,
            string pszExpand,
            string pszSelect,
            string pszHelpTopic,
            uint cnpvdeFlags,
            object pBrowse);


        int GetUniqueUINameOfProject(object pHierarchy, out string pbstrUniqueName);


        int CheckForAndSaveDeferredSaveSolution(
            int fCloseSolution,
            string pszMessage,
            string pszTitle,
            uint grfFlags);


        int UpdateProjectFileLocationForUpgrade(string pszCurrentLocation, string pszUpgradedLocation);
    }
}
