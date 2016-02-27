// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.IO;
using System.Linq;
using ShogunLib;
using ShogunLib.LINQ;

namespace Sketch.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public FileSystemEntries EnumerateEntries(string path)
        {
            path.ValidateStringEmpty("path");

            var entries = new FileSystemEntries();

            if (path == "\\")
            {
                Directory
                    .GetLogicalDrives()
                    .ForEach(x => entries.Add(new DirectoryEntry { FullName = x , Name = x, Parent = "\\"}));
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    throw new InvalidOperationException();
                }

                Directory
                   .EnumerateDirectories(path)
                   .Select(CreateDirectoryEntry)
                   .AddTo(entries);

                Directory
                    .EnumerateFiles(path)
                    .Select(CreateFileEntry)
                    .AddTo(entries);
            }

            return entries;
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteDirectory(string path, bool recurs)
        {
            Directory.Delete(path, recurs);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        private static DirectoryEntry CreateDirectoryEntry(string path)
        {
            var info = new DirectoryInfo(path);

            return new DirectoryEntry
            {
                Name = info.Name,
                FullName = info.FullName,
                Parent = info.Parent?.FullName
            };
        }

        private static FileEntry CreateFileEntry(string path)
        {
            var info = new FileInfo(path);

            return new FileEntry
            {
                Name = info.Name,
                FullName = info.FullName,
                Parent = info.Directory?.FullName
            };
        }
    }
}
