namespace Microsoft.VisualStudio.Shell.Interop
{
    public enum __VSSETTINGSCOMPLETIONSTATUS
    {

        vsSettingsCompletionStatusNotStarted = 0,

        vsSettingsCompletionStatusSuccess = 0,

        vsSettingsCompletionStatusIncomplete = 1,

        vsSettingsCompletionStatusComplete = 2,

        vsSettingsCompletionStatusStateMask = 15,

        vsSettingsCompletionStatusWarnings = 16,

        vsSettingsCompletionStatusErrors = 32,

        vsSettingsCompletionStatusSuccessMask = 240,
    }
}
