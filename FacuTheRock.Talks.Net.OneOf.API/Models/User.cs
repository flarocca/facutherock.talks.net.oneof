using System;

namespace FacuTheRock.Talks.Net.OneOf.API.Models
{
    public record User
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
