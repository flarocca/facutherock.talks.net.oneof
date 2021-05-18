using FacuTheRock.Talks.Net.OneOf.API.Exceptions;
using FacuTheRock.Talks.Net.OneOf.API.Models;
using FacuTheRock.Talks.Net.OneOf.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FacuTheRock.Talks.Net.OneOf.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService service;

        public UsersController(UserService service) =>
            this.service = service;

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(service.GetAll());

        [HttpGet("{id:guid}", Name = nameof(Get))]
        public IActionResult Get(Guid id) =>
            Ok(service.Get(id));

        #region V1

        [HttpPost("v1")]
        public IActionResult AddV1([FromBody] User userRequest)
        {
            var createdUser = service.Add(userRequest);

            return CreatedAtRoute(
                nameof(Get),
                createdUser,
                new { id = createdUser.Id });
        }

        #endregion

        #region V2

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

        [HttpPost("v2")]
        public IActionResult AddV2([FromBody] User userRequest)
        {
            try
            {
                var createdUser = service.Add(userRequest);

                return CreatedAtRoute(
                    nameof(Get),
                    createdUser,
                    new { id = createdUser.Id });
            }
            catch (InvalidUserNameBusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserAlreadyExistsBusinessException ex)
            {
                return Conflict(ex.Message);
            }
        }

        #endregion

        #region V3

        [HttpPost("v3")]
        public IActionResult AddV3([FromBody] User userRequest)
        {
            var createdUser = service.AddV3(userRequest);

            return createdUser.Match<IActionResult>(
                user => CreatedAtRoute(nameof(Get), user, new { id = user.Id }),
                userAlreadyExists => Conflict(),
                invalidUserName => BadRequest());
        }

        #endregion
    }
}
