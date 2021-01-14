namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProfileSettingsFileCollection
    {
        int GetCount(out int pCount);

        int GetSettingsFile( int index,  out object ppFileInfo);

        int AddBrowseFile( string bstrFilePath,  out object ppFileInfo);
    }
}
