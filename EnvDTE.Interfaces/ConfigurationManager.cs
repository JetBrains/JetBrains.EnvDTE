using System.Collections;

namespace EnvDTE
{
    public interface ConfigurationManager : IEnumerable
    {
        DTE DTE { get; }
        object Parent { get; }
        int Count { get; }
        object ConfigurationRowNames { get; }
        object PlatformNames { get; }
        object SupportedPlatforms { get; }
        Configuration ActiveConfiguration { get; }
        new IEnumerator GetEnumerator();
        Configuration Item(object index, string Platform = "");
        Configurations ConfigurationRow(string Name);

        Configurations AddConfigurationRow(
            string NewName,
            string ExistingName,
            bool Propagate);

        void DeleteConfigurationRow(string Name);
        Configurations Platform(string Name);
        Configurations AddPlatform(string NewName, string ExistingName, bool Propagate);
        void DeletePlatform(string Name);
    }
}
