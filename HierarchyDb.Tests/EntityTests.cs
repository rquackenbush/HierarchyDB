using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HierarchyDb.Client;
using HierarchyDb.Client.Model;
using HierarchyDb.Client.Storage;
using Xunit;

namespace HierarchyDb.Tests
{
    public class EntityTests
    {
        [Fact]
        public async Task CreateEntityDefinitionTest()
        {
            var storage = new InMemoryStorage();

            var client = new ProjectClient(storage);

            Guid entityDefinitionId = Guid.NewGuid();

            var entityDefinitionRequest = new CreateEntityDefinitionRequest()
            {
                Id = entityDefinitionId,
                Name = "Entity",
                Fields = new FieldDefinition[]{},
            };

            var entityDefinition = await client.CreateEntityDefinitionAsync(entityDefinitionRequest);

            Assert.NotNull(entityDefinition); 
            Assert.Equal(entityDefinitionId, entityDefinition.Id);

            var retreived = await client.GetEntityDefinitionAsync(entityDefinitionId);

            Assert.NotNull(retreived);
            Assert.Equal(entityDefinitionRequest.Name, retreived.Name);
        }

        //[Fact]
        //public void MissingEntityDefinitionTest()
        //{
        //    var client = new ProjectClient();

        //    Guid entityDefinitionId = Guid.NewGuid();

        //    Assert.Throws<EntityDefinitionNotFoundException>(() =>
        //        client.CreateEntity(entityDefinitionId, "Entity #1"));
        //}

        //[Fact]
        //public void MissingFieldDefinitionTest()
        //{
        //    var client = new ProjectClient();

        //    Guid entityDefinitionId = Guid.NewGuid();

        //    var entityDefinition = new EntityDefinition()
        //    {
        //        Id = entityDefinitionId,
        //        CreatedUtc = DateTime.UtcNow,
        //        Name = "Entity",
        //        Fields = new FieldDefinition[]{}
        //    };

        //    client.AddEntityDefinition(entityDefinition);

        //    Assert.Throws<FieldDefinitionNotFoundException>(() =>
        //    {
        //        client.CreateEntity(entityDefinitionId, "Entity #1", new Field[]
        //        {
        //            new Field()
        //            {
        //                FieldDefinitionId = Guid.NewGuid(),
        //                Value = "Hello"
        //            }
        //        });
        //    });
        //}
    }
}