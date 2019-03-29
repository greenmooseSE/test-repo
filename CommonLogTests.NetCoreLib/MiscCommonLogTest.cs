namespace CommonLogTests.NetCoreLib
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Common.NetStd;
    using Microsoft.Extensions.Logging;
    using NLog;
    using NLog.NetCoreLib;
    using NUnit.Framework;
    using Serilog.NetCoreLib;

    [TestFixture(TypeArgs = new[]{typeof(SeriLogContainer)})]
    [TestFixture(TypeArgs = new[]{typeof(NLogContainer)})]
    internal class MiscCommonLogTest<TLogContainer> : CommonLogTest<TLogContainer> where TLogContainer : LogContainer, new()
    {
        [Test]
        public void CanLogSomething()
        {
            pLog.LogDebug("Test");
        }
    }
}