// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Runtime.Serialization;
using Sketch.Repositories;

namespace Client.WPF
{
    [DataContract]
    public sealed class AgentEntity : Entity
    {
        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public string DisplayName { get; set; }
    }
}
