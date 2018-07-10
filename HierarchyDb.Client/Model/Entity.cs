using System;

namespace HierarchyDb.Client.Model
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Guid EntityDefinitionId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedUtc { get; set; }

        public Field[] Fields { get; set; }
    }
}