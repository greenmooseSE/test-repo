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
        public override IReadOnlyCollection<IMemoryLogEntry> LoggedEntries => MemoryLogTarget.Entries;

        public override void ClearLoggedEntries()
        {
            MemoryLogTarget.ClearEntries();
        }

        public override void AddLogging(ILoggingBuilder builder)
        {
            var cfg = new LoggingConfiguration();
            string layout =
                "${date}|${level: uppercase = true}|${message} ${exception}|${logger}|${all -event-properties }";
            cfg.AddTarget(new TraceTarget("trace") {Layout = layout});
            cfg.AddTarget(new MemoryLogTarget("memory") {Layout = layout});
            cfg.AddRuleForAllLevels("trace", "*");
            cfg.AddRuleForAllLevels("memory", "*");
            LogManager.Configuration = cfg;

            builder.AddNLog();
        }
    }
}