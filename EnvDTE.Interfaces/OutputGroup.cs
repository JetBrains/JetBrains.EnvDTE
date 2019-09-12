namespace EnvDTE
{
	public interface OutputGroup
	{
		DTE DTE { get; }
		OutputGroups Collection { get; }
		object FileNames { get; }
		int FileCount { get; }
		string DisplayName { get; }
		string CanonicalName { get; }
		object FileURLs { get; }
		string Description { get; }
	}
}
