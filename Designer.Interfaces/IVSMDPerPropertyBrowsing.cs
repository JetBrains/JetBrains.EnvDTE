using System;

namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDPerPropertyBrowsing
    {
        void GetPropertyAttributes(
            int dispid,
            out uint pceltAttrs,
            IntPtr ppbstrTypeNames,
            IntPtr ppvarAttrValues);
    }
}
