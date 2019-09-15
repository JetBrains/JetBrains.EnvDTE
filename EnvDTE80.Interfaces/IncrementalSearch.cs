using EnvDTE;

namespace EnvDTE80
{
    public interface IncrementalSearch
    {
        DTE DTE { get; }
        bool IncrementalSearchModeOn { get; }
        string Pattern { get; }
        void StartForward();
        void StartBackward();
        vsIncrementalSearchResult SearchWithLastPattern();
        vsIncrementalSearchResult AppendCharAndSearch(short Character);
        vsIncrementalSearchResult DeleteCharAndBackup();
        void Exit();
        vsIncrementalSearchResult SearchForward();
        vsIncrementalSearchResult SearchBackward();
    }
}
