
namespace PlatformService.Persistence.Models
{
    public record Platform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
