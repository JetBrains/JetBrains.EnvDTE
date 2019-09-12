namespace EnvDTE
{
	public interface _dispCommandEvents
	{
		void BeforeExecute(
			string Guid,
			int ID,
			object CustomIn,
			object CustomOut,
			ref bool CancelDefault);

		void AfterExecute(string Guid, int ID, object CustomIn, object CustomOut);
	}
}
