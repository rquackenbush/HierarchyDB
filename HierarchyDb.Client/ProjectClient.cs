using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HierarchyDb.Client.Model;
using HierarchyDb.Client.Storage;

namespace HierarchyDb.Client
{
    public class ProjectClient
    {
        private readonly StorageBase _storage;

        public ProjectClient(StorageBase storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public async Task<Entity> CreateEntityAsync(CreateEntityRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            var fields = request.Fields ?? new Field[] { };

            //Attempt to get the entity definition.
            var entityDefinition = await _storage.GetEntityDefinitionAsync(request.EntityDefinitionId, cancellationToken);

            if (entityDefinition == null)
                throw new EntityDefinitionNotFoundException($"Entity definition '{request.EntityDefinitionId}' not found.");

            foreach (var field in fields)
            {
                //Attempt to get the field definition
                var fieldDefinition = entityDefinition.Fields.FirstOrDefault(f => f.Id == field.FieldDefinitionId);

                if (fieldDefinition == null)
                    throw new FieldDefinitionNotFoundException($"Unable to find field definition '{field.FieldDefinitionId}'.");

                //TODO: Validate the data type.
            }

            //Create the entity
            var entity = new Entity()
            {
                Id = Guid.NewGuid(),
                EntityDefinitionId = request.EntityDefinitionId,
                Name = request.Name,
                Fields = fields,
                CreatedUtc = DateTime.UtcNow
            };

            //Add the entity to the backing store.
            await _storage.AddEntityAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<Entity> GetEntityAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _storage.GetEntityAsync(id, cancellationToken);
        }

        public async Task DeleteEntity(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            await _storage.DeleteEntityAsync(id, cancellationToken);
        }

        public async Task<Entity[]> GetEntitiesAsync(Guid entityDefinitionId, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _storage.GetEntitiesAsync(entityDefinitionId, cancellationToken);
        }

        public async Task<EntityDefinition> CreateEntityDefinitionAsync(CreateEntityDefinitionRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            var fields = request.Fields ?? new FieldDefinition[] { };

            if (request.Id == Guid.Empty)
                throw new InvalidOperationException($"The specified id contained the default value.");

            Guid id = request.Id ?? Guid.NewGuid();

            var entityDefinition = new EntityDefinition()
            {
                Id = id,
                Name = request.Name,
                IsConcrete = request.IsConcrete,
                Fields = fields,
                CreatedUtc = DateTime.UtcNow,
            };

            await _storage.AddEntityDefinitionAsync(entityDefinition, cancellationToken);

            return entityDefinition;
        }

        public Task<EntityDefinition> GetEntityDefinitionAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            return _storage.GetEntityDefinitionAsync(id, cancellationToken);
        }
    }
}