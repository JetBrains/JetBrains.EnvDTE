namespace EnvDTE
{
    public interface _EnvironmentDocuments
    {
        bool ReuseSavedActiveDocWindow { set; get; }
        bool DetectFileChangesOutsideIDE { set; get; }
        bool AutoloadExternalChanges { set; get; }
        bool InitializeOpenFileFromCurrentDocument { set; get; }
        int MiscFilesProjectSavesLastNItems { set; get; }
        bool FindReplaceShowMessageBoxes { get; set; }
        bool FindReplaceInitializeFromEditor { get; set; }
    }
}
