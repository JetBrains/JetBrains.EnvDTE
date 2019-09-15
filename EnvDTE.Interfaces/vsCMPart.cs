namespace EnvDTE
{
    public enum vsCMPart
    {
        vsCMPartName = 1,
        vsCMPartAttributes = 2,
        vsCMPartHeader = 4,
        vsCMPartHeaderWithAttributes = 6,
        vsCMPartWhole = 8,
        vsCMPartWholeWithAttributes = 10, // 0x0000000A
        vsCMPartBody = 16, // 0x00000010
        vsCMPartNavigate = 32, // 0x00000020
        vsCMPartAttributesWithDelimiter = 68, // 0x00000044
        vsCMPartBodyWithDelimiter = 80 // 0x00000050
    }
}
