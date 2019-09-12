namespace EnvDTE
{
	public interface _EnvironmentHelp
	{
		int PreferredLanguage { get; set; }
		string PreferredCollection { get; set; }
		bool External { get; set; }
	}
}
