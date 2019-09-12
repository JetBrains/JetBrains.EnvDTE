
using EnvDTE;


namespace EnvDTE80
{
	public interface IInternalExtenderProvider
	{
		object GetExtenderNames(string ExtenderCATID, object ExtendeeObject);

		object GetExtender(
			string ExtenderCATID,
			string ExtenderName,
			object ExtendeeObject,
			IExtenderSite ExtenderSite,
			int Cookie);

		bool CanExtend(string ExtenderCATID, string ExtenderName, object ExtendeeObject);
	}
}
