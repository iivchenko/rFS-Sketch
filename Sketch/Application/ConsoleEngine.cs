// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.ServiceModel;
using ShogunLib;
using Sketch.FileSystem;

namespace Sketch.Application
{
    public sealed class ConsoleEngine : IApplicationEngine
    {
        public void Run()
        {
            RunInternal(new string[0]);
        }

        public void Run(string[] args)
        {
            RunInternal(args);
        }

        private void RunInternal(string[] args)
        {
            Console.WriteLine("Starting server");

            using (var fsHost = new ServiceHost(typeof(FileSystemService)))
            using (var streamHost = new ServiceHost(typeof(FileStreamService)))
            {
                Console.WriteLine(fsHost.AsString("Hosting {0}", host => host.Description.Name));
                fsHost.Open();

                Console.WriteLine(streamHost.AsString("Hosting {0}", host => host.Description.Name));
                streamHost.Open();

                Console.WriteLine("Server started");
                Console.WriteLine("Type 'exit' to stop server");

                while (true)
                {
                    var command = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(command) && command.ToLower().Equals("exit"))
                    {
                        break;
                    }
                }
            }
        }
    }
}
