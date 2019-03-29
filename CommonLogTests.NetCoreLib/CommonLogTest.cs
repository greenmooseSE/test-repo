namespace CommonLogTests.NetCoreLib
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Common.NetStd;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    [TestFixture]
    internal abstract class CommonLogTest<TLogContainer> where TLogContainer : LogContainer, new()
    {
        [SetUp]
        public void CommonLogTestSetUp()
        {
            pLog = _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(GetType().Name);
        }

        private static readonly ServiceProvider _serviceProvider;

        public ILogger pLog { get; private set; }

        ///<summary>One-time only construction logic.</summary>
        [ExcludeFromCodeCoverage]
        static CommonLogTest()
        {
            var container = new TLogContainer();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                container.AddLogging(builder);
            });

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}