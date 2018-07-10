using System;
using System.Runtime.Serialization;

namespace HierarchyDb.Client
{
    public class EntityDefinitionNotFoundException : Exception
    {
        public EntityDefinitionNotFoundException()
        {
        }

        public EntityDefinitionNotFoundException(string message) : base(message)
        {
        }

        public EntityDefinitionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityDefinitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}