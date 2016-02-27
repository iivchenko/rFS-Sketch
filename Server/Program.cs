// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using Sketch.Application;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ApplicationEngineFactory()
                .Create()
                .Run(args);
        }
    }
}
