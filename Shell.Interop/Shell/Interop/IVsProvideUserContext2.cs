namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProvideUserContext2
    {
        int GetUserContextEx(out object ppctx, out int iPriority);
    }
}
