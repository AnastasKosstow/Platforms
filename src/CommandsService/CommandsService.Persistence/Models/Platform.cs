using System.Collections.Generic;

namespace CommandsService.Persistence.Models
{
    public record Platform
    {
        public int Id { get; set; }
        
        public int ExternalId { get; set; }

        public string Name { get; set; }

        ICollection<Command> Commands { get; set; }
    }
}
