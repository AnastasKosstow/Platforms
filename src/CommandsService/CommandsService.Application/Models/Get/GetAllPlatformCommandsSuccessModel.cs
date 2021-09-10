
using System.Collections.Generic;

namespace CommandsService.Application.Models.Get
{
    public record GetAllPlatformCommandsSuccessModel
    {
        public GetAllPlatformCommandsSuccessModel(IEnumerable<CommandModel> commands)
        {
            Commands = commands;
        }
        public IEnumerable<CommandModel> Commands { get; set; }
    }

    public record CommandModel
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public int PlatformId { get; set; }
    }
}
