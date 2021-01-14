using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSingleFileGeneratorFactory
    {
        int GetDefaultGenerator(string wszFilename, out string pbstrGenProgID);

        int CreateGeneratorInstance(
            string wszProgId,
            out int pbGeneratesDesignTimeSource,
            out int pbGeneratesSharedDesignTimeSource,
            out int pbUseTempPEFlag,
            out object ppGenerate);

        int GetGeneratorInformation(
            string wszProgId,
            out int pbGeneratesDesignTimeSource,
            out int pbGeneratesSharedDesignTimeSource,
            out int pbUseTempPEFlag,
            out Guid pguidGenerator);
    }
}
