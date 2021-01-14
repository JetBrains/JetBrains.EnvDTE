using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPackageDynamicToolOwnerEx
    {
        int QueryShowTool( ref Guid rguidPersistenceSlot,  uint dwId,  out int pfShowTool);
    }
}
