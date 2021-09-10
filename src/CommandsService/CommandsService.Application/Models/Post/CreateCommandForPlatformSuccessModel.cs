
namespace CommandsService.Application.Models.Post
{
    public record CreateCommandForPlatformSuccessModel
    {
        public CreateCommandForPlatformSuccessModel(object entity)
        {
            Entity = entity;
        }
        public object Entity { get; set; }
    }
}
