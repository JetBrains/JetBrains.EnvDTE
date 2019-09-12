namespace EnvDTE
{
	public enum vsCMFunction
	{
		vsCMFunctionOther = 0,
		vsCMFunctionConstructor = 1,
		vsCMFunctionPropertyGet = 2,
		vsCMFunctionPropertyLet = 4,
		vsCMFunctionPropertySet = 8,
		vsCMFunctionPutRef = 16, // 0x00000010
		vsCMFunctionPropertyAssign = 32, // 0x00000020
		vsCMFunctionSub = 64, // 0x00000040
		vsCMFunctionFunction = 128, // 0x00000080
		vsCMFunctionTopLevel = 256, // 0x00000100
		vsCMFunctionDestructor = 512, // 0x00000200
		vsCMFunctionOperator = 1024, // 0x00000400
		vsCMFunctionVirtual = 2048, // 0x00000800
		vsCMFunctionPure = 4096, // 0x00001000
		vsCMFunctionConstant = 8192, // 0x00002000
		vsCMFunctionShared = 16384, // 0x00004000
		vsCMFunctionInline = 32768, // 0x00008000
		vsCMFunctionComMethod = 65536 // 0x00010000
	}
}
