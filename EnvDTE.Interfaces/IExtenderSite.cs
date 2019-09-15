namespace EnvDTE
{
    public interface IExtenderSite
    {
        void NotifyDelete(int Cookie);
        object GetObject(string Name = "");
    }
}
