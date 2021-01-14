namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsTrackProjectDocumentsEvents3
    {
        int OnBeginQueryBatch();


        int OnEndQueryBatch(out int pfActionOK);


        int OnCancelQueryBatch();


        int OnQueryAddFilesEx(
            object pProject,
            int cFiles,
            string[] rgpszNewMkDocuments,
            string[] rgpszSrcMkDocuments,
            object[] rgFlags,
            object[] pSummaryResult,
            object[] rgResults);


        int HandsOffFiles(uint grfRequiredAccess, int cFiles, string[] rgpszMkDocuments);


        int HandsOnFiles(int cFiles, string[] rgpszMkDocuments);
    }
}
