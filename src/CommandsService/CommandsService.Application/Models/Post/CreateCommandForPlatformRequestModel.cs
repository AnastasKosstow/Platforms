
namespace CommandsService.Application.Models.Post
{
    public record CreateCommandForPlatformRequestModel
    {
        public int PlatformId { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }
    }
}
