using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IBuilderWizardManager
    {
        int DoesBuilderExist(ref Guid rguidBuilder);

        int MapObjectToBuilderCLSID(
            ref Guid rclsidObject,
            uint dwPromptOpt,
            IntPtr hwndPromptOwner,
            out Guid pclsidBuilder);


        int MapBuilderCATIDToCLSID(
            ref Guid rguidBuilder,
            uint dwPromptOpt,
            IntPtr hwndPromptOwner,
            out Guid pclsidBuilder);

        int GetBuilder(
            ref Guid rguidBuilder,
            uint grfGetOpt,
            IntPtr hwndPromptOwner,
            out object ppdispApp,
            out IntPtr pwndBuilderOwner,
            ref Guid riidBuilder,
            out object ppunkBuilder);


        int EnableModeless(int fEnable);
    }
}
