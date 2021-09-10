
namespace CommandsService.Application.Models.Get
{
    public record GetCommandForPlatformRequestModel
    {
        public int PlatformId { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }
    }
}
