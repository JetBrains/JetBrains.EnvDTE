using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWindowPaneCommitFilter
    {
        int IsCommitCommand(ref Guid pguidCmdGroup, uint dwCmdID, out int pfCommitCommand);
    }
}
