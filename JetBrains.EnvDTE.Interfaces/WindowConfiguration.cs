namespace EnvDTE
{
	public interface WindowConfiguration
	{
		string this[] { get; }
		DTE DTE { get; }
		WindowConfigurations Collection { get; }
		void Apply(bool FromCustomViews = true);
		void Delete();
		void Update();
	}
}
