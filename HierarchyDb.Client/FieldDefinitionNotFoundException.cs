using System;
using System.Runtime.Serialization;

namespace HierarchyDb.Client
{
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