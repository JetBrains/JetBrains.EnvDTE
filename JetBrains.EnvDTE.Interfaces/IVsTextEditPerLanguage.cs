namespace EnvDTE
{
	public interface IVsTextEditPerLanguage
	{
		short TabSize { set; get; }
		short IndentSize { set; get; }
		bool InsertTabs { set; get; }
		vsIndentStyle IndentStyle { set; get; }
		bool AutoListMembers { set; get; }
		bool AutoListParams { set; get; }
		bool VirtualSpace { set; get; }
		bool EnableLeftClickForURLs { set; get; }
		bool WordWrap { set; get; }
		bool ShowLineNumbers { set; get; }
		bool ShowNavigationBar { set; get; }
		bool HideAdvancedMembers { set; get; }
	}
}
