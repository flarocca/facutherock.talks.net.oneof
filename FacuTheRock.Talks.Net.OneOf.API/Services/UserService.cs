using FacuTheRock.Talks.Net.OneOf.API.Exceptions;
using FacuTheRock.Talks.Net.OneOf.API.Models;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacuTheRock.Talks.Net.OneOf.API.Services
{
    public class UserService
    {
        private readonly IDictionary<Guid, User> users = new Dictionary<Guid, User>();

        public User Add(User user)
        {
            if (users.ContainsKey(user.Id))
                throw new UserAlreadyExistsBusinessException(user.Id);

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new InvalidUserNameBusinessException(user.Name);

            users.Add(user.Id, user);

            return user;
        }

        #region V3

        #region Pros & Cons

        /* ****************************************
         * PROS:
         *   - Mecanismo provisto por el framework
         *   - Single Responsibility Principle
         *   - Solución conocida
         * 
         * Cons:
         *   - Reglas de negocio en la API
         *   - Reglas de negocio como excepciones
         * 
         * ****************************************/

        #endregion

        public OneOf<User, UserAlreadyExistsBusinessException, InvalidUserNameBusinessException> AddV3(User user)
        {
            if (users.ContainsKey(user.Id))
                return new UserAlreadyExistsBusinessException(user.Id);

            if (string.IsNullOrWhiteSpace(user.Name))
                return new InvalidUserNameBusinessException(user.Name);

            users.Add(user.Id, user);

            return user;
        }

        #endregion

        public IReadOnlyCollection<User> GetAll() =>
                users.Select(item => item.Value).ToList();

        public User Get(Guid id) =>
            users[id];
    }
}
