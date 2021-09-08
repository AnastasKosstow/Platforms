
namespace PlatformService.Application.Models.Post
{
    public record CreatePlatformRequestModel
    {
        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
