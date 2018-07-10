using System;

namespace HierarchyDb.Client.Model
{
    public class CreateEntityDefinitionRequest
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public FieldDefinition[] Fields { get; set; }

        public bool IsConcrete { get; set; }
    }
}