namespace Common.NetStd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    public abstract class LogContainer
    {
        public abstract void ClearLoggedEntries();
        public abstract IReadOnlyCollection<IMemoryLogEntry> LoggedEntries { get; }
        public abstract void AddLogging(ILoggingBuilder builder);
    }
}