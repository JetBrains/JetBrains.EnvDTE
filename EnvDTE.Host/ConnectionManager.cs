using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host
{
    [PublicAPI]
    public sealed class ConnectionManager
    {
        private const string Host = "T4 Communication Host";
        private const string Protocol = "T4 Communication Protocol";

        public ConnectionManager(Lifetime lifetime)
        {
            var model = SetupModel(lifetime);
            RegisterCallbacks(model);
        }

        [NotNull]
        private static T4ProtocolModel SetupModel(Lifetime lifetime)
        {
            var scheduler = SingleThreadScheduler.RunOnSeparateThread(lifetime, Host);
            var server = new SocketWire.Server(lifetime, scheduler);
            var serializers = new Serializers();
            var identities = new Identities(IdKind.Server);
            var protocol = new Protocol(Protocol, serializers, identities, scheduler, server, lifetime);
            return new T4ProtocolModel(lifetime, protocol);
        }

        private static void RegisterCallbacks(T4ProtocolModel model)
        {
        }
    }
}
