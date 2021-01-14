using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAddNewWebProjectItemDlg
    {
    int AddNewWebProjectItemDlg(
       uint itemidLoc,
       ref Guid rguidProject,
       object pProject,
       string pszDlgTitle,
       string lpszHelpTopic,
       string lpszLanguage,
       string lpszSelect,
       uint options);
    }
}
