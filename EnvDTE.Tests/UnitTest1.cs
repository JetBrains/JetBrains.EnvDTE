using JetBrains.Annotations;
using JetBrains.EnvDTE.Host;
using JetBrains.Lifetimes;
using NUnit.Framework;

namespace JetBrains.EnvDTE.Tests
{
    public sealed class Tests
    {
        [NotNull]
        private LifetimeDefinition Definition { get; set; }

        [NotNull]
        private ConnectionManager HostConnectionManager { get; set; }

        [NotNull]
        private EnvDTE.Client.ConnectionManager ClientConnectionManager { get; set; }

        [SetUp]
        public void Setup()
        {
            Definition = new LifetimeDefinition();
            // Lifetime library should've been referenced through EnvDTE.Client project
            HostConnectionManager = new ConnectionManager(Definition.Lifetime, null);
            ClientConnectionManager = new EnvDTE.Client.ConnectionManager(Definition.Lifetime, HostConnectionManager.Port);
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
