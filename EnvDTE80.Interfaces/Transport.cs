using EnvDTE;

namespace EnvDTE80
{
    public interface Transport
    {
        string Name { get; }
        string ID { get; }
        Engines Engines { get; }
        DTE DTE { get; }
        Debugger2 Parent { get; }
        Transports Collection { get; }
    }
}
