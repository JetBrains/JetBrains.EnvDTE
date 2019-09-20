using JetBrains.Annotations;
using JetBrains.EnvDTE.Client;
using JetBrains.Lifetimes;
using NUnit.Framework;

namespace JetBrains.EnvDTE.Tests
{
    public sealed class Tests
    {
        [NotNull] private LifetimeDefinition Definition { get; set; }

        [NotNull] private Host.ConnectionManager HostConnectionManager { get; set; }

        [NotNull] private ConnectionManager ClientConnectionManager { get; set; }

        [SetUp]
        public void Setup()
        {
            Definition = new LifetimeDefinition();
            // Lifetime library should be same version in client and host version
            HostConnectionManager = new Host.ConnectionManager(Definition.Lifetime, null);
            ClientConnectionManager = new ConnectionManager(Definition.Lifetime, HostConnectionManager.Port);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown() => Definition.Terminate();
    }
}
