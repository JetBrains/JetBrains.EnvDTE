namespace EnvDTE
{
	public enum vsCMPrototype
	{
		vsCMPrototypeFullname = 1,
		vsCMPrototypeNoName = 2,
		vsCMPrototypeClassName = 4,
		vsCMPrototypeParamTypes = 8,
		vsCMPrototypeParamNames = 16, // 0x00000010
		vsCMPrototypeParamDefaultValues = 32, // 0x00000020
		vsCMPrototypeUniqueSignature = 64, // 0x00000040
		vsCMPrototypeType = 128, // 0x00000080
		vsCMPrototypeInitExpression = 256 // 0x00000100
	}
}
