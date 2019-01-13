using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wynathan.Stellaris.Common.IO.FileAccessor;

namespace Wynathan.Stellaris.Common.IO
{
    public class SynchronisedFileAccessor : IReadWriteFileAccessor, IReadFileAccessor, IWriteFileAccessor, IDisposable
    {
        private readonly string filePath;
        private readonly string mutexName;
        private readonly Mutex mutex;

        private const char invalidCharacterReplacement = '_';
        private static readonly string invalidCharacterReplacementString = invalidCharacterReplacement.ToString();
        private static readonly char[] invalidPathCharacters;

        static SynchronisedFileAccessor()
        {
            var invalidPathChars = Path.GetInvalidPathChars();
            var invalidFileNameChars = Path.GetInvalidFileNameChars();
            // It might be an overkill, but let us make sure we neither miss 
            // not duplicated any.
            invalidPathCharacters = invalidPathChars.Union(invalidFileNameChars)
                .Distinct()
                .ToArray();
        }

        public SynchronisedFileAccessor(string filePath)
        {
            this.filePath = filePath;
            this.mutexName = this.AcquireMutexName();
            this.mutex = new Mutex(false, mutexName);
        }

        public string ReadAll()
        {
            try
            {
                this.mutex.WaitOne();
                return File.ReadAllText(this.filePath);
            }
            finally
            {
                this.mutex.ReleaseMutex();
            }
        }

        public void Write(string content)
        {
            try
            {
                this.mutex.WaitOne();
                File.WriteAllText(this.filePath, content);
            }
            finally
            {
                this.mutex.ReleaseMutex();
            }
        }

        private string AcquireMutexName()
        {
            var mutexName = this.filePath;
            foreach (var character in invalidPathCharacters)
                mutexName = mutexName.Replace(character, invalidCharacterReplacement);

            var doubleReplacement = new string(invalidCharacterReplacement, 2);
            int doubleReplacementIndex;
            while (true)
            {
                doubleReplacementIndex = mutexName.IndexOf(doubleReplacement);
                if (doubleReplacementIndex < 0)
                    break;

                mutexName = mutexName.Replace(doubleReplacement, invalidCharacterReplacementString);
            }

            return mutexName;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                try
                {
                    this.mutex.ReleaseMutex();
                    this.mutex.Dispose();
                }
                catch (ObjectDisposedException)
                {
                    // It's all right.
                }
                catch (Exception)
                {

                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileAccessor() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
