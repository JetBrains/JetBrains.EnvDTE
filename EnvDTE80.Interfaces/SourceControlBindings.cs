using EnvDTE;

namespace EnvDTE80
{
    public interface SourceControlBindings
    {
        DTE DTE { get; }
        SourceControl Parent { get; }
        string ServerName { get; }
        string LocalBinding { get; }
        string ServerBinding { get; }
        string ProviderName { get; }
        string ProviderRegKey { get; }
    }
}
