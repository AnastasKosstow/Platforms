
namespace PlatformService.Application.Models.Post
{
    public record CreatePlatformSuccessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
