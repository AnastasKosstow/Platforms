using PlatformService.Mediator.Abstractions;

namespace PlatformService.Application.Models.Delete
{
    public record DeletePlatformRequestModel : IRequest<DeletePlatformSuccessModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
