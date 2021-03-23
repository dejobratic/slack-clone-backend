using System;

namespace SlackClone.Core.Exceptions
{
    public class EntityAlreadyExistsException :
        Exception
    {
        public EntityAlreadyExistsException(Type type)
            : base($"{type.Name} already exists.")
        {
        }
    }
}
