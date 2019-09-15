using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Rd.Impl;

namespace JetBrains.EnvDTE.Host
{
    [PublicAPI]
    public sealed class ConnectionManager
    {
        public ConnectionManager()
        {
            var lifetime = Lifetime.Eternal;
            var scheduler = SingleThreadScheduler.RunOnSeparateThread(lifetime, "Rider communicator");
            var server = new SocketWire.Server(lifetime, scheduler);
        }
    }
}
