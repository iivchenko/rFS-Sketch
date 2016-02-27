// <copyright company = "XATA" >
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Sketch.Repositories
{
    public sealed class XmlRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly string _path;
        private readonly object _lock;

        private readonly DataContractSerializer _serializer;

        public XmlRepository(string path)
        {
            _path = path;
            _lock = new object();
            _serializer = new DataContractSerializer(typeof(Collection<TEntity>));
        }

        public uint Count
        {
            get
            {
                return (uint)Lock(() => Read().Count);
            }
        }

        public void Add(TEntity entity)
        {
            Lock(() =>
            {
                var entities = Read();

                entity.EntityId =
                    entities.Any()
                        ? entities.Max(x => x.EntityId) + 1
                        : 1;

                entities.Add(entity);

                Write(entities);
            });
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Lock(() => Read().Where(predicate.Compile()));
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Lock(() => Read().GetEnumerator());
        }

        public void Remove(TEntity entity)
        {
            Lock(() =>
            {
                var entities = Read();

                entities.Remove(entities.Single(x => x.EntityId == entity.EntityId));

                Write(entities);
            });
        }

        public void Update(TEntity entity)
        {
            Lock(() =>
            {
                var entities = Read();

                entities.Remove(entities.Single(x => x.EntityId == entity.EntityId));

                entities.Add(entity);

                Write(entities);
            });
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Lock(GetEnumerator);
        }

        private Collection<TEntity> Read()
        {
            if (!File.Exists(_path))
            {
                return new Collection<TEntity>();
            }

            using (var file = File.Open(_path, FileMode.Open))
            {
                return (Collection<TEntity>)_serializer.ReadObject(file);
            }
        }

        private void Write(Collection<TEntity> entities)
        {
            using (var file = File.Open(_path, FileMode.Create))
            {
                _serializer.WriteObject(file, entities);
            }
        }

        private void Lock(Action action)
        {
            lock (_lock)
            {
                action();
            }
        }

        private T Lock<T>(Func<T> func)
        {
            lock (_lock)
            {
                return func();
            }
        }
    }
}