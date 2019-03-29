using System;
using System.Collections.Generic;
using System.Text;

namespace Serilog.NetCoreLib
{
    using Common.NetStd;
    using Serilog.Events;

    class SeriLogSinkEntry : IMemoryLogEntry
    {
        private readonly LogEvent _logEvent;

        public SeriLogSinkEntry(string message, LogEvent logEvent)
        {
            RenderedMessage = message;
            _logEvent = logEvent;
        }

        public string RenderedMessage { get; }
    }
}
