namespace EnvDTE
{
    public enum DsTextSearchOptions
    {
        dsMatchForward = 0,
        dsMatchNoRegExp = 0,
        dsMatchWord = 2,
        dsMatchCase = 4,
        dsMatchRegExp = 8,
        dsMatchRegExpB = 16, // 0x00000010
        dsMatchRegExpE = 32, // 0x00000020
        dsMatchRegExpCur = 64, // 0x00000040
        dsMatchBackward = 128, // 0x00000080
        dsMatchFromStart = 256 // 0x00000100
    }
}
