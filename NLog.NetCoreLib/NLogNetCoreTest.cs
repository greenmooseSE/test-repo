namespace NLog.NetCoreLib
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NLog.Config;
    using NLog.Extensions.Logging;
    using NLog.Targets;
    using NUnit.Framework;

    [TestFixture]
    internal abstract class NLogNetCoreTest
    {
        [SetUp]
        public void NLogNetCoreTestSetUp()
        {
            pLog = _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(GetType().Name);
        }

        private static readonly ServiceProvider _serviceProvider;

        ///<summary>One-time only construction logic.</summary>
        static NLogNetCoreTest()
        {
            var cfg = new LoggingConfiguration();
            string layout =
                "${date}|${level: uppercase = true}|${message} ${exception}|${logger}|${all -event-properties }";
            //var consoleTarget = new ConsoleTarget("console") {Layout = layout};
            //var traceTarget = new TraceTarget("trace") { Layout = layout };
            //var allRule = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            //allRule.Targets.Add(traceTarget);
            //cfg.AddTarget(consoleTarget);
            //cfg.AddTarget(traceTarget);
            cfg.AddTarget(new TraceTarget("trace") {Layout = layout});
            cfg.AddRuleForAllLevels("trace", "*");
            LogManager.Configuration = cfg;

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();
            });
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected ILogger pLog { get; private set; }
    }
}