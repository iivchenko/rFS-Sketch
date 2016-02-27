// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.ServiceModel;
using System.ServiceProcess;
using Sketch.FileSystem;

namespace Sketch.Application
{
    public class Service : ServiceBase
    {
        private ServiceHost _fsHost;
        private ServiceHost _streamHost;

        protected override void OnStart(string[] args)
        {
            _fsHost = new ServiceHost(typeof(FileSystemService));
            _streamHost = new ServiceHost(typeof(FileStreamService));

            _fsHost.Open();
            _streamHost.Open();

            base.OnStart(args);
        }

        protected override void OnStop()
        {
            _fsHost.Close();
            _streamHost.Close();

            base.OnStop();
        }
    }
}
