// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.ServiceProcess;

namespace Sketch.Application
{
    public sealed class WindowsServiceEngine : IApplicationEngine
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
            ServiceBase.Run(new Service());
        }
    }
}
