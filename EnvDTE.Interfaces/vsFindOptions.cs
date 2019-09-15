namespace EnvDTE
{
    public enum vsFindOptions
    {
        vsFindOptionsNone = 0,
        vsFindOptionsMatchWholeWord = 2,
        vsFindOptionsMatchCase = 4,
        vsFindOptionsRegularExpression = 8,
        vsFindOptionsBackwards = 128, // 0x00000080
        vsFindOptionsFromStart = 256, // 0x00000100
        vsFindOptionsMatchInHiddenText = 512, // 0x00000200
        vsFindOptionsWildcards = 1024, // 0x00000400
        vsFindOptionsSearchSubfolders = 4096, // 0x00001000
        vsFindOptionsKeepModifiedDocumentsOpen = 8192 // 0x00002000
    }
}
