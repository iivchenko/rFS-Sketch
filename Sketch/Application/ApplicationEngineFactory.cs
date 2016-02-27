// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;

namespace Sketch.Application
{
    public sealed class ApplicationEngineFactory : IApplicationEngineFactory
    {
        public IApplicationEngine Create()
        {
            return Environment.UserInteractive
                ? (IApplicationEngine) new ConsoleEngine()
                : (IApplicationEngine) new WindowsServiceEngine();
        }
    }
}
