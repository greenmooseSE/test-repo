namespace NLog.NetCoreLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Common.NetStd;
    using Microsoft.Extensions.Logging;
    using NLog.Config;
    using NLog.Extensions.Logging;
    using NLog.Targets;

    public class NLogContainer : LogContainer
    {
        public override void ClearLoggedEntries()
        {
            throw new NotImplementedException("TODO:(stesun01/20190329) Implement ClearLoggedEntries.");
        }

        public override IReadOnlyCollection<IMemoryLogEntry> LoggedEntries { get; }

        public override void AddLogging(ILoggingBuilder builder)
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

            builder.AddNLog();
        }
    }
}