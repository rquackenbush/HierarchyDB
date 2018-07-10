using System;

namespace HierarchyDb.Client.Model
{
    public class FieldDefinition
    {
        public Guid Id { get; set; }

        public Guid DataTypeId { get; set; }

        public string Name { get; set; }
    }
}