namespace EnvDTE
{
    public interface SolutionConfiguration
    {
        DTE DTE { get; }
        SolutionConfigurations Collection { get; }
        string Name { get; }
        SolutionContexts SolutionContexts { get; }
        void Delete();
        void Activate();
    }
}
