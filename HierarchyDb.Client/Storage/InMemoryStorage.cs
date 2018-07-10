using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HierarchyDb.Client.Model;

namespace HierarchyDb.Client.Storage
{
    public class InMemoryStorage : StorageBase
    {
        private readonly Dictionary<Guid, Entity> _entities = new Dictionary<Guid, Entity>();
        private readonly Dictionary<Guid, EntityDefinition> _entityDefinitions = new Dictionary<Guid, EntityDefinition>();

        public override Task<EntityDefinition> GetEntityDefinitionAsync(Guid id, CancellationToken cancellationToken)
        {
            _entityDefinitions.TryGetValue(id, out var entityDefinition);

            return Task.FromResult(entityDefinition);
        }

        public override Task<Entity> GetEntityAsync(Guid id, CancellationToken cancellationToken)
        {
            _entities.TryGetValue(id, out var entity);

            return Task.FromResult(entity);
        }

        public override Task AddEntityAsync(Entity entity, CancellationToken cancellationToken)
        {
            _entities.Add(entity.Id, entity);

            return Task.CompletedTask;
        }

        public override Task DeleteEntityAsync(Guid entityId, CancellationToken cancellationToken)
        {
            _entities.Remove(entityId);

            return Task.CompletedTask;
        }

        public override Task<Entity[]> GetEntitiesAsync(Guid entityDefinitionId, CancellationToken cancellationToken)
        {
            var entities = _entities.Values
                .Where(e => e.EntityDefinitionId == entityDefinitionId)
                .ToArray();

            return Task.FromResult(entities);
        }

        public override Task AddEntityDefinitionAsync(EntityDefinition entityDefinition, CancellationToken cancellationToken)
        {
            _entityDefinitions.Add(entityDefinition.Id, entityDefinition);

            return Task.CompletedTask;
        }
    }
}