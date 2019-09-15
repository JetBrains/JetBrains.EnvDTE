namespace EnvDTE80
{
    public enum vsCMChangeKind
    {
        vsCMChangeKindRename = 1,
        vsCMChangeKindUnknown = 2,
        vsCMChangeKindSignatureChange = 4,
        vsCMChangeKindTypeRefChange = 8,
        vsCMChangeKindBaseChange = 16, // 0x00000010
        vsCMChangeKindArgumentChange = 32 // 0x00000020
    }
}
