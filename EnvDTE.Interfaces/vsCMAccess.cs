namespace EnvDTE
{
	public enum vsCMAccess
	{
		vsCMAccessPublic = 1,
		vsCMAccessPrivate = 2,
		vsCMAccessProject = 4,
		vsCMAccessProtected = 8,
		vsCMAccessProjectOrProtected = 12, // 0x0000000C
		vsCMAccessDefault = 32, // 0x00000020
		vsCMAccessAssemblyOrFamily = 64, // 0x00000040
		vsCMAccessWithEvents = 128 // 0x00000080
	}
}
