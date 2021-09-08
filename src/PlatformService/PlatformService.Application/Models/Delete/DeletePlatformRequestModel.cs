
namespace PlatformService.Application.Models.Delete
{
    public record DeletePlatformRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
