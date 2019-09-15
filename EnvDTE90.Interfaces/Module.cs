using EnvDTE;

namespace EnvDTE90
{
    public interface Module
    {
        string Name { get; }
        string Path { get; }
        bool Optimized { get; }
        bool UserCode { get; }
        string SymbolFile { get; }
        uint Order { get; }
        string Version { get; }
        ulong LoadAddress { get; }
        ulong EndAddress { get; }
        bool Rebased { get; }
        DTE DTE { get; }
        Debugger Parent { get; }
        Modules Collection { get; }
        Process Process { get; }
        bool Is64bit { get; }
        void LoadSymbols(string SymbolPath);
    }
}
