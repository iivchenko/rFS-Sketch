// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.ServiceModel;

namespace Sketch.FileSystem
{
    [ServiceContract]
    public interface IFileSystemService
    {
        [OperationContract]
        FileSystemEntries EnumerateEntries(string path);

        [OperationContract]
        void CreateDirectory(string path);

        [OperationContract]
        void DeleteDirectory(string path, bool recurs);

        [OperationContract]
        void DeleteFile(string path);
    }
}
