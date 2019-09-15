namespace EnvDTE
{
    public interface IExtensibleObject
    {
        void GetAutomationObject(string Name, IExtensibleObjectSite pParent, out object ppDisp);
    }
}
