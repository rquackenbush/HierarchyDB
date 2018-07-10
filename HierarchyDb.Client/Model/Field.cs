using System;

namespace HierarchyDb.Client.Model
{
    public class Field
    {
        public Guid FieldDefinitionId { get; set; }

        public object Value { get; set; }
    }
}
