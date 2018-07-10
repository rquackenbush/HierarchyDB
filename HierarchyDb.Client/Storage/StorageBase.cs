using System;
using System.Threading;
using System.Threading.Tasks;
using HierarchyDb.Client.Model;

namespace HierarchyDb.Client.Storage
{
    public abstract class StorageBase
    {
        public abstract Task<EntityDefinition> GetEntityDefinitionAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<Entity> GetEntityAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task AddEntityAsync(Entity entity, CancellationToken cancellationToken);

        public abstract Task DeleteEntityAsync(Guid entityId, CancellationToken cancellationToken);

        public abstract Task<Entity[]> GetEntitiesAsync(Guid entityDefinitionId, CancellationToken cancellationToken);

        public abstract Task AddEntityDefinitionAsync(EntityDefinition entityDefinition, CancellationToken cancellationToken);
    }
}