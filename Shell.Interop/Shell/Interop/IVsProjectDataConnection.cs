namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectDataConnection
    {
        int GetProjectSqlConnection(out object pConnection);
    }
}
