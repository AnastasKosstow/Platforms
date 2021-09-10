
namespace CommandsService.Application.Models.Post
{
    public record CreateCommandForPlatformRequestModel
    {
        public int PlatformId { get; set; }

        public CommandArgs Command { get; set; }

        public record CommandArgs
        {
            public string HowTo { get; set; }

            public string CommandLine { get; set; }
        }
    }
}
