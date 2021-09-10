
namespace CommandsService.Application.Models.Get
{
    public record GetCommandForPlatformSuccessModel
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }
    }
}
