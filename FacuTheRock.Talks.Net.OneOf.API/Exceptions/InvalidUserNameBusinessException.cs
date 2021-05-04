using System;

namespace FacuTheRock.Talks.Net.OneOf.API.Exceptions
{
    public class InvalidUserNameBusinessException : BusinessException
    {
        public InvalidUserNameBusinessException(string name)
            : base($"User name cannot be empty")
        {
            Name = name;
        }

        public string Name { get; }
    }
}
