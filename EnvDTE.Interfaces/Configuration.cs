namespace EnvDTE
{
    public interface Configuration
    {
        DTE DTE { get; }
        ConfigurationManager Collection { get; }
        string ConfigurationName { get; }
        string PlatformName { get; }
        vsConfigurationType Type { get; }
        object Owner { get; }
        Properties Properties { get; }
        bool IsBuildable { get; }
        bool IsRunable { get; }
        bool IsDeployable { get; }
        object Object { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        OutputGroups OutputGroups { get; }
        object get_Extender(string ExtenderName);
    }
}
