namespace Serilog.NetCoreLib
{
    using System;
    using System.Linq;
    using Serilog.Configuration;

    internal static class MemorySinkConfigExtension

    {
        public static LoggerConfiguration MyMemorySink(this LoggerSinkConfiguration loggerConfiguration,
            IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new MemorySink(formatProvider));
        }
    }
}