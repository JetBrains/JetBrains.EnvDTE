namespace EnvDTE80
{
    public enum vsCMOverrideKind
    {
        vsCMOverrideKindNone = 0,
        vsCMOverrideKindAbstract = 1,
        vsCMOverrideKindVirtual = 2,
        vsCMOverrideKindOverride = 4,
        vsCMOverrideKindNew = 8,
        vsCMOverrideKindSealed = 16 // 0x00000010
    }
}
