namespace EnvDTE
{
	public enum vsTaskListColumn
	{
		vsTaskListColumnPriority = 1,
		vsTaskListColumnGlyph = 2,
		vsTaskListColumnCheck = 4,
		vsTaskListColumnDescription = 8,
		vsTaskListColumnFile = 16, // 0x00000010
		vsTaskListColumnLine = 32 // 0x00000020
	}
}
