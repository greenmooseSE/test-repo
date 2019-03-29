namespace Common.NetStd
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    public abstract class LogContainer
    {
        public abstract void AddLogging(ILoggingBuilder builder);
    }
}