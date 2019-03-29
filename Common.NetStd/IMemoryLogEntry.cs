namespace Common.NetStd
{
    using System;
    using System.Linq;

    public interface IMemoryLogEntry
    {
        string RenderedMessage { get; }
    }
}