
namespace CommandsService.Infrastructure.Messaging.Models
{
    public record PlatformPublishModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Event { get; set; }
    }
}
