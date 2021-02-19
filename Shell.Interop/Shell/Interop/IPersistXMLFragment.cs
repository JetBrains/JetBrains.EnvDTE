using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IPersistXMLFragment
    {
        int InitNew(ref Guid guidFlavor, uint storage);

        int IsFragmentDirty(uint storage, out int pfDirty);

        int Load(ref Guid guidFlavor, uint storage, string pszXMLFragment);

        int Save(ref Guid guidFlavor, uint storage, out string pbstrXMLFragment, int fClearDirty);
    }
}
