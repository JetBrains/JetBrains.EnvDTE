using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectFlavorCfg
    {
        int get_CfgType(ref Guid iidCfg, out IntPtr ppCfg);

        int Close();
    }
}
