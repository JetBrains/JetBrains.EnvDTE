using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
  public interface IErrorInfo
  {
    int GetGuid(out Guid pGuid);

    int GetSource(out string pBstrSource);

    int GetDescription(out string pbstrDescription);

    int GetHelpFile(out string pBstrHelpFile);

    int GetHelpContext(out uint pdwHelpContext);
  }
}
