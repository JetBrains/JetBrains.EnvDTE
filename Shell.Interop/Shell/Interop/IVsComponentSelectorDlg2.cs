using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsComponentSelectorDlg2
    {
    int ComponentSelectorDlg2(
         uint grfFlags,
       object pUser,
       uint cComponents,
       IntPtr[] rgpcsdComponents,
         string lpszDlgTitle,
       string lpszHelpTopic,
       ref uint pxDlgSize,
       ref uint pyDlgSize,
       uint cTabInitializers,
         object[] rgcstiTabInitializers,
       ref Guid pguidStartOnThisTab,
       string pszBrowseFilters,
       ref string pbstrBrowseLocation);
    }
}
