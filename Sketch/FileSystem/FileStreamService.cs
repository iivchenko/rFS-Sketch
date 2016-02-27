// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace Sketch.FileSystem
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class FileStreamService : IFileStreamService
    {
        public FileStreamService()
        {
            OperationContext.Current.Channel.Closed += CloseStreamHandler;
        }

        private Stream _stream;

        public bool CanRead => _stream.CanRead;

        public bool CanSeek => _stream.CanSeek;

        public bool CanWrite => _stream.CanWrite;

        public long Length => _stream.Length;

        public long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }

        public void Initialize(string path, FileMode mode)
        {
            if (_stream != null)
            {
                throw new InvalidOperationException();
            }

            _stream = new FileStream(path, mode);
        }

        public void Flush()
        {
            _stream.Flush();
        }

        public byte[] Read(int count)
        {
            var buffer = new byte[count];

            var read = _stream.Read(buffer, 0, count);

            return
                read != 0
                    ? read == count
                        ? buffer
                        : buffer.Take(read).ToArray()
                    : null;
        }

        public long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public void Write(byte[] buffer)
        {
            _stream.Write(buffer, 0, buffer.Length);
        }

        private void CloseStreamHandler(object sender, EventArgs e)
        {
            _stream.Dispose();
            _stream = null;
        }
    }
}