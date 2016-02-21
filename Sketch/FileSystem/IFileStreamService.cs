// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.IO;
using System.ServiceModel;

namespace Sketch.FileSystem
{
    [ServiceContract]
    public interface IFileStreamService
    {
        bool CanRead {[OperationContract] get; }

        bool CanSeek {[OperationContract] get; }

        bool CanWrite {[OperationContract] get; }

        long Length {[OperationContract] get; }

        long Position {[OperationContract] get;[OperationContract] set; }

        [OperationContract]
        void Initialize(string path, FileMode mode);

        [OperationContract]
        void Flush();

        [OperationContract]
        byte[] Read(int count);

        [OperationContract]
        long Seek(long offset, SeekOrigin origin);

        [OperationContract]
        void SetLength(long value);

        [OperationContract]
        void Write(byte[] buffer);
    }
}
