namespace EnvDTE
{
	public enum vsCommandStatus
	{
		vsCommandStatusUnsupported = 0,
		vsCommandStatusSupported = 1,
		vsCommandStatusEnabled = 2,
		vsCommandStatusLatched = 4,
		vsCommandStatusNinched = 8,
		vsCommandStatusInvisible = 16 // 0x00000010
	}
}
