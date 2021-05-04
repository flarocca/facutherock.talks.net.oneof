using System;

namespace FacuTheRock.Talks.Net.OneOf.API.Exceptions
{
    public class UserAlreadyExistsBusinessException : BusinessException
    {
        public UserAlreadyExistsBusinessException(Guid userId)
            : base($"User with id {userId} already exists.")
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
