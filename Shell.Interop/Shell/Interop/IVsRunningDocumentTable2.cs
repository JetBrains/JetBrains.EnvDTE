using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsRunningDocumentTable2
    {
        int CloseDocuments(uint grfSaveOptions, object pHierarchy, uint docCookie);

        int QueryCloseRunningDocument(string pszMkDocument, out int pfFoundAndClosed);

        int FindAndLockDocumentEx(
            uint grfRDTLockType,
            string pszMkDocument,
            object pHierPreferred,
            uint itemidPreferred,
            out object ppHierActual,
            out uint pitemidActual,
            out IntPtr ppunkDocDataActual,
            out uint pdwCookie);

        int FindOrRegisterAndLockDocument(
            uint grfRDTLockType,
            string pszMkDocument,
            object pHierPreferred,
            uint itemidPreferred,
            IntPtr punkDocData,
            out object ppHierActual,
            out uint pitemidActual,
            out IntPtr ppunkDocDataActual,
            out uint pdwCookie);
    }
}
