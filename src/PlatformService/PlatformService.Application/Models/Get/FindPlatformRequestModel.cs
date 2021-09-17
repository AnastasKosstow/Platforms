using PlatformService.Mediator.Abstractions;

namespace PlatformService.Application.Models.Get
{
    public record FindPlatformRequestModel : IRequest<FindPlatformSuccessModel>
    {
        public int Id { get; set; }
    }
}
