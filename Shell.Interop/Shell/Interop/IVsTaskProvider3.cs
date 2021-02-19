using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsTaskProvider3
    {
        int GetProviderFlags(out uint tpfFlags);


        int GetProviderName(out string pbstrName);


        int GetProviderGuid(out Guid pguidProvider);


        int GetSurrogateProviderGuid(out Guid pguidProvider);


        int GetProviderToolbar(out Guid pguidGroup, out uint pdwID);


        int GetColumnCount(out int pnColumns);


        int GetColumn(int iColumn, VSTASKCOLUMN[] pColumn);


        int OnBeginTaskEdit(object pItem);


        int OnEndTaskEdit(object pItem, int fCommitChanges, out int pfAllowChanges);
    }
}
