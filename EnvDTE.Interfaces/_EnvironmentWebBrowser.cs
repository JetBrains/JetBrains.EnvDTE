namespace EnvDTE
{
	public interface _EnvironmentWebBrowser
	{
		bool UseDefaultHomePage { set; get; }
		string HomePage { set; get; }
		bool UseDefaultSearchPage { set; get; }
		string SearchPage { set; get; }
		vsBrowserViewSource ViewSourceIn { set; get; }
		string ViewSourceExternalProgram { set; get; }
	}
}
