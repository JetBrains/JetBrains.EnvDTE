namespace EnvDTE80
{
    public enum vsCMParameterKind
    {
        vsCMParameterKindNone = 0,
        vsCMParameterKindIn = 1,
        vsCMParameterKindRef = 2,
        vsCMParameterKindOut = 4,
        vsCMParameterKindOptional = 8,
        vsCMParameterKindParamArray = 16 // 0x00000010
    }
}
