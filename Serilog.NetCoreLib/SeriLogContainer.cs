namespace Serilog.NetCoreLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.NetStd;
    using Microsoft.Extensions.Logging;

    public class SeriLogContainer : LogContainer
    {
        public override IReadOnlyCollection<IMemoryLogEntry> LoggedEntries => MyMemorySink.Entries;

        public override void ClearLoggedEntries()
        {
            MyMemorySink.ClearEntries();
        }

        public override void AddLogging(ILoggingBuilder builder)
        {
            //Weird way of initializing a configuration for Serilog, setting a static logger?
            Log.Logger = new LoggerConfiguration().WriteTo.Trace().WriteTo.MyMemorySink()
                //Required in order to log something
                .MinimumLevel.Debug().Enrich.FromLogContext().CreateLogger();

            //Logger logger = logCfg.CreateLogger();
            Log.Logger.Debug("Logging initialized.");

            builder.AddSerilog(dispose: true);
        }
    }
}