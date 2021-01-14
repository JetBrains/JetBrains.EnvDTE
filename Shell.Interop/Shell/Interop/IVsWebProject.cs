using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWebProject
    {
        int AddNewWebItem(
            uint itemidLoc,
            object dwAddItemOperation,
            string pszItemName,
            string pszFileTemplate,
            uint options,
            string pszSelectedLanguage,
            IntPtr hwndDlgOwner,
            object[] pResult);
    }
}
