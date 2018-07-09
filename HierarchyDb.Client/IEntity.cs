using System;

namespace HierarchyDb.Client
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Guid EntityDefinitionId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedUtc { get; set; }

        public Field[] Fields { get; set; }
    }

    public class Field
    {
        public Guid FieldDefinitionId { get; set; }

        public object Value { get; set; }
    }

    public class EntityDefinition
    {
        public Guid Id { get; set;  }

        public Guid? ParentId { get; set; }

        public FieldDefinition[] Fields { get; set; }

        public string Name { get; set; }

        public DateTime CreatedUtc { get; set; }
    }

    public class FieldDefinition
    {
        public Guid Id { get; set; }

        public Guid DataTypeId { get; set; }

        public string Name { get; set; }
    }
}
