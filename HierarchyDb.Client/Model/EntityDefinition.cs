using System;

namespace HierarchyDb.Client.Model
{
    public class EntityDefinition
    {
        public Guid Id { get; set;  }

        public Guid? ParentId { get; set; }

        public FieldDefinition[] Fields { get; set; }

        public string Name { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsConcrete { get; set; }
    }
}