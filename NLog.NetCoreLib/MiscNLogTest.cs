namespace NLog.NetCoreLib
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    [TestFixture]
    internal class MiscNLogTest : NLogNetCoreTest
    {
        [Test]
        public void CanLogSomething()
        {
            pLog.LogDebug("test");
        }
    }
}