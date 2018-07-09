using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HierarchyDb.Client
{
    public class ProjectClient
    {
        private Dictionary<Guid, Entity> _entities = new Dictionary<Guid, Entity>();
        public Dictionary<Guid, EntityDefinition> _entityDefinitions = new Dictionary<Guid, EntityDefinition>();

        public Entity CreateEntity(Guid entityDefinitionId, string name, Field[] fields = null)
        {
            fields = fields ?? new Field[] { };

            //Attempt to get the entity definition.
            if (!_entityDefinitions.TryGetValue(entityDefinitionId, out var entityDefinition))
                throw new EntityDefinitionNotFoundException($"Entity definition '{entityDefinitionId}' not found.");

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
                EntityDefinitionId = entityDefinitionId,
                Name = name,
                Fields = fields,
                CreatedUtc = DateTime.UtcNow
            };

            //Add the entity to the backing store.
            _entities.Add(entity.Id, entity);

            return entity;
        }

        public Entity GetEntity(Guid id)
        {
            if (_entities.TryGetValue(id, out var entity))
                return entity;

            return null;
        }

        public void DeleteEntity(Guid id)
        {
            if (!_entities.Remove(id))
                throw new EntityNotFoundException($"Unable to delete entity {id}.");
        }

        public Entity[] GetEntities(Guid entityDefinitionId)
        {
            return _entities.Values
                .Where(e => e.EntityDefinitionId == entityDefinitionId)
                .ToArray();
        }

        public EntityDefinition AddEntityDefinition(EntityDefinition entityDefinition)
        {
            _entityDefinitions.Add(entityDefinition.Id, entityDefinition);

            return entityDefinition;
        }
    }

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class EntityDefinitionNotFoundException : Exception
    {
        public EntityDefinitionNotFoundException()
        {
        }

        public EntityDefinitionNotFoundException(string message) : base(message)
        {
        }

        public EntityDefinitionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityDefinitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class FieldDefinitionNotFoundException : Exception
    {
        public FieldDefinitionNotFoundException()
        {
        }

        public FieldDefinitionNotFoundException(string message) : base(message)
        {
        }

        public FieldDefinitionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FieldDefinitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}