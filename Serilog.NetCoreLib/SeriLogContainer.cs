using System;
using System.Collections.Generic;
using System.Text;

namespace Serilog.NetCoreLib
{
    using Common.NetStd;
    using Microsoft.Extensions.Logging;

    public class SeriLogContainer : LogContainer
    {
        public override void AddLogging(ILoggingBuilder builder)
        {
            //Weird way of initializing a configuration for Serilog, setting a static logger?
            Log.Logger = new LoggerConfiguration().WriteTo.Trace()
                //Required in order to log something
                .MinimumLevel.Debug().Enrich.FromLogContext().CreateLogger();

            //Logger logger = logCfg.CreateLogger();
            Log.Logger.Debug("Logging initialized.");

            builder.AddSerilog(dispose: true);
        }
    }
}
