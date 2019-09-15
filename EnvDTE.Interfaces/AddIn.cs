namespace EnvDTE
{
    public interface AddIn
    {
        string Description { get; set; }
        AddIns Collection { get; }
        string ProgID { get; }
        string Guid { get; }
        bool Connected { get; set; }
        object Object { get; set; }
        DTE DTE { get; }
        string Name { get; }
        string SatelliteDllPath { get; }
        void Remove();
    }
}
