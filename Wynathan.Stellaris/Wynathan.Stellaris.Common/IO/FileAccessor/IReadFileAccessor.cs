using System;

namespace Wynathan.Stellaris.Common.IO.FileAccessor
{
    public interface IReadFileAccessor : IDisposable
    {
        string ReadAll();
    }
}
