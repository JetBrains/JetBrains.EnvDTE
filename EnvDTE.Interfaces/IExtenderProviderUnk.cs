namespace EnvDTE
{
    public interface IExtenderProviderUnk
    {
        object GetExtender(
            string ExtenderCATID,
            string ExtenderName,
            object ExtendeeObject,
            IExtenderSite ExtenderSite,
            int Cookie);

        bool CanExtend(string ExtenderCATID, string ExtenderName, object ExtendeeObject);
    }
}
