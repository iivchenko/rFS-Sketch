// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShogunLib;
using ShogunLib.Events;
using Sketch.Repositories;

namespace Client.WPF
{
    public sealed class AgentsStorage : IRepository<AgentEntity>
    {
        private readonly IRepository<AgentEntity> _repository;

        public AgentsStorage(IRepository<AgentEntity> repository)
        {
            repository.ValidateNull("repository");

            _repository = repository;
        }

        public EventHandler<SimpleEventArgs<AgentEntity>> AgentAdded;
        public EventHandler<SimpleEventArgs<AgentEntity>> AgentRemoved;
        public EventHandler<SimpleEventArgs<AgentEntity>> AgentUpdated;

        public IEnumerator<AgentEntity> GetEnumerator()
        {
            return _repository.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public uint Count
        {
            get { return _repository.Count; }
        }

        public void Add(AgentEntity entity)
        {
            _repository.Add(entity);

            AgentAdded.Raise(this, entity);
        }

        public void Remove(AgentEntity entity)
        {
            _repository.Remove(entity);

            AgentRemoved.Raise(this, entity);
        }

        public void Update(AgentEntity entity)
        {
            _repository.Update(entity);

            AgentUpdated.Raise(this, entity);
        }

        public IEnumerable<AgentEntity> Find(Expression<Func<AgentEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }
    }
}
