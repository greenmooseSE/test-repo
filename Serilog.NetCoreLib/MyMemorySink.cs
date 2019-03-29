namespace Serilog.NetCoreLib
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Serilog.Core;
    using Serilog.Events;

    internal class MyMemorySink : ILogEventSink
    {
        private static readonly ConcurrentBag<SeriLogSinkEntry> _entries =
            new ConcurrentBag<SeriLogSinkEntry>();

        private readonly IFormatProvider _formatProvider;

        public MyMemorySink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public static IReadOnlyCollection<SeriLogSinkEntry> Entries => _entries;

        public void Emit(LogEvent logEvent)
        {
            string message = logEvent.RenderMessage(_formatProvider);
            _entries.Add(new SeriLogSinkEntry(message, logEvent));
        }

        public static void ClearEntries()
        {
            _entries.Clear();
        }
    }
}