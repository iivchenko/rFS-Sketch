// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Sketch.FileSystem
{
    [CollectionDataContract]
    public class FileSystemEntries : Collection<FileSystemEntry>
    {
    }
}
