namespace EnvDTE
{
	public interface IDTToolsOptionsPage
	{
		void OnAfterCreated(DTE DTEObject);
		void GetProperties(ref object PropertiesObject);
		void OnOK();
		void OnCancel();
		void OnHelp();
	}
}
