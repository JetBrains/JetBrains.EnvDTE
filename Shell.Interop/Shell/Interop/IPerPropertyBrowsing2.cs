using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IPerPropertyBrowsing2
    {
        int MapPropertyToBuilder(int dispid, out Guid pguidBuilder, out uint pdwType);

        int ExecuteBuilder(
            int dispid,
            ref Guid rguidBuilder,
            object pdispApp,
            IntPtr hwndBuilderOwner,
            ref object pvarValue);
    }
}
