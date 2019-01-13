using System;

namespace Wynathan.Stellaris.Common.IO.FileAccessor
{
    public interface IReadWriteFileAccessor : IReadFileAccessor, IWriteFileAccessor, IDisposable
    {
    }
}
