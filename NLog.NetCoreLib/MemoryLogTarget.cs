namespace NLog.NetCoreLib
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using NLog.Targets;

    internal class MemoryLogTarget : TargetWithLayout
    {
        public MemoryLogTarget(string name)
        {
            Name = name;
        }

        private static readonly ConcurrentBag<NLogEntry> _entries = new ConcurrentBag<NLogEntry>();

        public static IReadOnlyCollection<NLogEntry> Entries => _entries;

        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = Layout.Render(logEvent);
            _entries.Add(new NLogEntry(logMessage, logEvent));
        }

        public static void ClearEntries()
        {
            _entries.Clear();
        }
    }
}