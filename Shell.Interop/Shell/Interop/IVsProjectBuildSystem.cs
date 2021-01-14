namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectBuildSystem
    {
        int SetHostObject(string pszTargetName, string pszTaskName, object punkHostObject);

        int StartBatchEdit();

        int EndBatchEdit();

        int CancelBatchEdit();

        int BuildTarget(string pszTargetName, out bool pbSuccess);

        int GetBuildSystemKind(out uint pBuildSystemKind);
    }
}
