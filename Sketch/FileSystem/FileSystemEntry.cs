// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Runtime.Serialization;

namespace Sketch.FileSystem
{
    [KnownType(typeof(DirectoryEntry))]
    [KnownType(typeof(FileEntry))]
    [DataContract]
    public abstract class FileSystemEntry
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Parent { get; set; }
    }
}
