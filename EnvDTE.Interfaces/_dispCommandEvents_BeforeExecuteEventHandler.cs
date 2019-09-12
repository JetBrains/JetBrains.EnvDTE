namespace EnvDTE
{
	public delegate void _dispCommandEvents_BeforeExecuteEventHandler(
		string Guid,
		int ID,
		object CustomIn,
		object CustomOut,
		ref bool CancelDefault);
}
