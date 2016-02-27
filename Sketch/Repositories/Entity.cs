// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Runtime.Serialization;

namespace Sketch.Repositories
{
    [DataContract]
    public abstract class Entity
    {
        [DataMember]
        internal ulong EntityId { get; set; }
    }
}
