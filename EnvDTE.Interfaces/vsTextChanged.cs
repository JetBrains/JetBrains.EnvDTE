namespace EnvDTE
{
    public enum vsTextChanged
    {
        vsTextChangedMultiLine = 1,
        vsTextChangedSave = 2,
        vsTextChangedCaretMoved = 4,
        vsTextChangedReplaceAll = 8,
        vsTextChangedNewline = 16, // 0x00000010
        vsTextChangedFindStarting = 32 // 0x00000020
    }
}
