namespace NLog.NetCoreLib
{
    using System;
    using System.Linq;
    using global::Common.NetStd;

    internal class NLogEntry : IMemoryLogEntry
    {
        private readonly LogEventInfo _logEvent;

        public NLogEntry(string logMessage, LogEventInfo logEvent)
        {
            _logEvent = logEvent;
            RenderedMessage = logMessage;
        }

        public string RenderedMessage { get; }
    }
}