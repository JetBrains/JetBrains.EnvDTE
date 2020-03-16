using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Platform.RdFramework.Impl;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.Rider.Model;
using JetBrains.Util.Logging;

namespace JetBrains.EnvDTE.Client
{
    [PublicAPI]
    public sealed class ConnectionManager
    {
        private const string Protocol = "EnvDTE Communication Protocol";

        [NotNull]
        public DteProtocolModel Model { get; }

        public ConnectionManager(Lifetime lifetime, int port) => Model = SetupModel(lifetime, port);

        [NotNull]
        private static DteProtocolModel SetupModel(Lifetime lifetime, int port)
        {
            IScheduler scheduler = new SimpleInpaceExecutingScheduler(Logger.GetLogger<ConnectionManager>());
            var server = new SocketWire.Client(lifetime, scheduler, port);
            var serializers = new Serializers();
            var identities = new Identities(IdKind.Client);
            var protocol = new Protocol(Protocol, serializers, identities, scheduler, server, lifetime);
            return new DteProtocolModel(lifetime, protocol);
        }
    }
}
