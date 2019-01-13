using System;

namespace Wynathan.Stellaris.Common.IO.FileAccessor
{
    public interface IWriteFileAccessor : IDisposable
    {
        void Write(string content);
    }
}
