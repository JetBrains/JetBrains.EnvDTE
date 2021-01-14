using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsDetermineWizardTrust
    {
        int OnWizardInitiated( string pszTemplateFilename, ref Guid guidProjectType);

        int OnWizardCompleted();

        int IsWizardRunning( out int pfWizardRunning);

        int GetRunningWizardTemplateName( out string pbstrRunningTemplate);

        int GetWizardTrustLevel( out uint pdwWizardTrustLevel);

        int SetWizardTrustLevel( uint dwWizardTrustLevel);
    }
}
