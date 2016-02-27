using System;
using System.Linq;
using System.Runtime.Serialization;
using NUnit.Framework;
using ShogunLib.LINQ;
using Sketch.Repositories;

namespace Sketch.Tests.Integration.Repositories
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void Test()
        {
            var repository = new XmlRepository<XmlEntity>("D:\\Repo.xml");

            repository.Add(new XmlEntity() { Name = "Hello"});
            repository.Add(new XmlEntity() { Name = "Hello2" });

            repository.ForEach(x => Console.WriteLine(x.Name));

            var element = repository.Find(x => x.Name == "Hello").First();

            Console.WriteLine("Count: {0}\n", repository.Count);

            repository.Remove(element);

            repository.ForEach(x => Console.WriteLine(x.Name));
            Console.WriteLine("Count: {0}\n", repository.Count);

            var element2 = repository.Find(x => x.Name == "Hello2").First();

            element2.Name = "NewHelo2";

            repository.Update(element2);

            repository.ForEach(x => Console.WriteLine(x.Name));
            Console.WriteLine("Count: {0}\n", repository.Count);
        }
    }

    [DataContract]
    public sealed class XmlEntity : Entity
    {
        [DataMember]
        public string Name { get; set; }
    }
}
