// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace Sketch.Application
{
    public interface IApplicationEngine
    {
        void Run();

        void Run(string[] args);
    }
}
