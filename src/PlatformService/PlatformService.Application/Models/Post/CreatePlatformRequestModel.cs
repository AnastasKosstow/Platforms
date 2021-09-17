using PlatformService.Mediator.Abstractions;

namespace PlatformService.Application.Models.Post
{
    public record CreatePlatformRequestModel : IRequest<CreatePlatformSuccessModel>
    {
        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
