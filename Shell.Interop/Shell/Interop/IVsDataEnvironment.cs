using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsDataEnvironment
    {
        int Initialize(IServiceProvider pServiceProvider);

        int Dispose();
    }
}
