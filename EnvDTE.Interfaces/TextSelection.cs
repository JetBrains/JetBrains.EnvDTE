namespace EnvDTE
{
    public interface TextSelection
    {
        DTE DTE { get; }
        TextDocument Parent { get; }
        VirtualPoint AnchorPoint { get; }
        VirtualPoint ActivePoint { get; }
        int AnchorColumn { get; }
        int BottomLine { get; }
        VirtualPoint BottomPoint { get; }
        int CurrentColumn { get; }
        int CurrentLine { get; }
        bool IsEmpty { get; }
        bool IsActiveEndGreater { get; }
        string Text { get; set; }
        int TopLine { get; }
        VirtualPoint TopPoint { get; }
        TextPane TextPane { get; }
        vsSelectionMode Mode { get; set; }
        TextRanges TextRanges { get; }
        void ChangeCase(vsCaseOptions How);
        void CharLeft(bool Extend = false, int Count = 1);
        void CharRight(bool Extend = false, int Count = 1);
        void ClearBookmark();
        void Collapse();
        void OutlineSection();
        void Copy();
        void Cut();
        void Paste();
        void Delete(int Count = 1);
        void DeleteLeft(int Count = 1);
        void DeleteWhitespace(vsWhitespaceOptions Direction = vsWhitespaceOptions.vsWhitespaceOptionsHorizontal);
        void EndOfLine(bool Extend = false);

        void StartOfLine(vsStartOfLineOptions Where = vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn,
            bool Extend = false);

        void EndOfDocument(bool Extend = false);
        void StartOfDocument(bool Extend = false);
        bool FindPattern(string Pattern, int vsFindOptionsValue = 0, TextRanges Tags = null);

        bool ReplacePattern(
            string Pattern,
            string Replace,
            int vsFindOptionsValue = 0,
            TextRanges Tags = null);

        bool FindText(string Pattern, int vsFindOptionsValue = 0);
        bool ReplaceText(string Pattern, string Replace, int vsFindOptionsValue = 0);
        void GotoLine(int Line, bool Select = false);
        void Indent(int Count = 1);
        void Unindent(int Count = 1);
        void Insert(string Text, int vsInsertFlagsCollapseToEndValue = 1);
        void InsertFromFile(string File);
        void LineDown(bool Extend = false, int Count = 1);
        void LineUp(bool Extend = false, int Count = 1);
        void MoveToPoint(TextPoint Point, bool Extend = false);
        void MoveToLineAndOffset(int Line, int Offset, bool Extend = false);
        void MoveToAbsoluteOffset(int Offset, bool Extend = false);
        void NewLine(int Count = 1);
        void SetBookmark();
        bool NextBookmark();
        bool PreviousBookmark();
        void PadToColumn(int Column);
        void SmartFormat();
        void SelectAll();
        void SelectLine();
        void SwapAnchor();
        void Tabify();
        void Untabify();
        void WordLeft(bool Extend = false, int Count = 1);
        void WordRight(bool Extend = false, int Count = 1);
        void Backspace(int Count = 1);
        void Cancel();
        void DestructiveInsert(string Text);
        void MoveTo(int Line, int Column, bool Extend = false);
        void MoveToDisplayColumn(int Line, int Column, bool Extend = false);
        void PageUp(bool Extend = false, int Count = 1);
        void PageDown(bool Extend = false, int Count = 1);
    }
}
