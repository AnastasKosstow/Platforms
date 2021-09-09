﻿
namespace CommandsService.Persistence.Models
{
    public record Command
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
