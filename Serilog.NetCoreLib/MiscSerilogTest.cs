namespace Serilog.NetCoreLib
{
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    [TestFixture]
    internal class MiscSerilogTest : SerilogNetCoreTest
    {
        [Test]
        public void CanLogSomething()
        {
            pLog.LogDebug("test");
        }
    }
}