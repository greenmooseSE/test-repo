namespace Serilog.NetCoreLib
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    /// <summary>
    ///     Drawbacks with serilog:
    ///     * It references Microsoft.AspNetCore.Hosting 
    ///     * Seem to only support 1 config instance via static Log.Logger property.
    /// </summary>
    [TestFixture]
    internal abstract class SerilogNetCoreTest
    {
        [SetUp]
        public void SerilogNetCoreTestSetUp()
        {
            pLog = _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(GetType().Name);
        }

        private static readonly ServiceProvider _serviceProvider;
        protected ILogger pLog { get; private set; }

        ///<summary>One-time only construction logic.</summary>
        [ExcludeFromCodeCoverage]
        static SerilogNetCoreTest()
        {
            //Weird way of initializing a configuration for Serilog, setting a static logger?
            Log.Logger = new LoggerConfiguration().WriteTo.Trace()
                //Required in order to log something
                .MinimumLevel.Debug().Enrich.FromLogContext().CreateLogger();

            //Logger logger = logCfg.CreateLogger();
            Log.Logger.Debug("Logging initialized.");

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddSerilog(dispose: true);
            });
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}