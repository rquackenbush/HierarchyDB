using System;

namespace HierarchyDb.Client.Model
{
    public class CreateEntityRequest
    {
        public Guid EntityDefinitionId { get; set; }

        public string Name { get; set; }

        public Field[] Fields { get; set; }
    }
}