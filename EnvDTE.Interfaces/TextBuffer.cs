namespace EnvDTE
{
    public interface TextBuffer
    {
        Window Parent { get; }
        DTE DTE { get; }
        int CountOfLines { get; }
        void AddFromString(string String, int StartLine = 1);
        void AddFromFile(string FileName, int StartLine = 1);
        string get_Lines(int StartLine, int Count);
        void DeleteLines(int StartLine, int Count = 1);

        bool Find(
            string Target,
            ref int StartLine,
            ref int StartColumn,
            ref int EndLine,
            ref int EndColumn,
            bool WholeWord = false,
            bool MatchCase = false,
            bool PatternSearch = false);
    }
}
