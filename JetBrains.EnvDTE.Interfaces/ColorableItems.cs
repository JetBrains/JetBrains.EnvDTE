namespace EnvDTE
{
	public interface ColorableItems
	{
		string this[] { get; }
		uint Foreground { get; set; }
		uint Background { get; set; }
		bool Bold { get; set; }
	}
}
