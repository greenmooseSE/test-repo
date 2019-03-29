namespace CommonLogTests.NetCoreLib
{
    using System;
    using System.Linq;
    using Common.NetStd;
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using NLog.NetCoreLib;
    using NUnit.Framework;
    using Serilog.NetCoreLib;

    [TestFixture(TypeArgs = new[] {typeof(SeriLogContainer)})]
    [TestFixture(TypeArgs = new[] {typeof(NLogContainer)})]
    internal class MiscCommonLogTest<TLogContainer> : CommonLogTest<TLogContainer>
        where TLogContainer : LogContainer, new()
    {
        [SetUp]
        public void MiscCommonLogTestSetUp()
        {
            pLogContainer.ClearLoggedEntries();
        }

        [Test]
        public void CanLogStructuredData()
        {
            pLog.LogDebug("Created user {UserName}, age {Age}", "John", 28);
        }

        [Test]
        public void CanLogToMemoryLogger()
        {
            pLogContainer.LoggedEntries.Should().BeEmpty();
            string what = Guid.NewGuid().ToString();
            pLog.LogDebug(what);
            pLog.LogDebug("2");

            pLogContainer.LoggedEntries.Select(x => x.RenderedMessage).Should().Contain(msg => msg != null)
                .Which.Should().Contain(what);
        }

        [Test]
        public void CanLogWithoutThrow()
        {
            pLog.LogDebug("Test");
        }
    }
}