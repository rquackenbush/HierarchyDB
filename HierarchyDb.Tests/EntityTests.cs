using System;
using HierarchyDb.Client;
using Xunit;

namespace HierarchyDb.Tests
{
    public class EntityTests
    {
        [Fact]
        public void SimpleTest()
        {
            var client = new ProjectClient();

            Guid entityDefinitionId = Guid.NewGuid();

            var entityDefinition = new EntityDefinition()
            {
                Id = entityDefinitionId,
                CreatedUtc = DateTime.UtcNow,
                Name = "Entity",
                Fields = new FieldDefinition[]{}
            };

            client.AddEntityDefinition(entityDefinition);

            client.CreateEntity(entityDefinitionId, "Entity #1");

            var entities = client.GetEntities(entityDefinitionId);

            Assert.Single(entities);

            Assert.Equal(entityDefinitionId, entities[0].EntityDefinitionId);
        }

        [Fact]
        public void MissingEntityDefinitionTest()
        {
            var client = new ProjectClient();

            Guid entityDefinitionId = Guid.NewGuid();

            Assert.Throws<EntityDefinitionNotFoundException>(() =>
                client.CreateEntity(entityDefinitionId, "Entity #1"));
        }

        [Fact]
        public void MissingFieldDefinitionTest()
        {
            var client = new ProjectClient();

            Guid entityDefinitionId = Guid.NewGuid();

            var entityDefinition = new EntityDefinition()
            {
                Id = entityDefinitionId,
                CreatedUtc = DateTime.UtcNow,
                Name = "Entity",
                Fields = new FieldDefinition[]{}
            };

            client.AddEntityDefinition(entityDefinition);

            Assert.Throws<FieldDefinitionNotFoundException>(() =>
            {
                client.CreateEntity(entityDefinitionId, "Entity #1", new Field[]
                {
                    new Field()
                    {
                        FieldDefinitionId = Guid.NewGuid(),
                        Value = "Hello"
                    }
                });
            });
        }
    }
}