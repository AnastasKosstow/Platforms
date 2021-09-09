using System.Collections.Generic;
using CommandsService.Persistence.Abstractions;

namespace CommandsService.Persistence.Models
{
    public record Platform : IPersistenceModel
    {
        public int Id { get; set; }
        
        public int ExternalId { get; set; }

        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}
