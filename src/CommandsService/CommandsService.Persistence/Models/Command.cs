using CommandsService.Persistence.Abstractions;

namespace CommandsService.Persistence.Models
{
    public record Command : IPersistenceModel
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
