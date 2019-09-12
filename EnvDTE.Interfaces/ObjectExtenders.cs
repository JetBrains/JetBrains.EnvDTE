namespace EnvDTE
{
	public interface ObjectExtenders
	{
		DTE DTE { get; }
		DTE Parent { get; }

		int RegisterExtenderProvider(
			string ExtenderCATID,
			string ExtenderName,
			IExtenderProvider ExtenderProvider,
			string LocalizedName = "");

		void UnregisterExtenderProvider(int Cookie);
		object GetExtender(string ExtenderCATID, string ExtenderName, object ExtendeeObject);
		object GetExtenderNames(string ExtenderCATID, object ExtendeeObject);
		object GetContextualExtenderCATIDs();
		string GetLocalizedExtenderName(string ExtenderCATID, string ExtenderName);

		int RegisterExtenderProviderUnk(
			string ExtenderCATID,
			string ExtenderName,
			IExtenderProviderUnk ExtenderProvider,
			string LocalizedName = "");
	}
}
