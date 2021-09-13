using System.Threading.Tasks;

namespace PlatformService.Mediator.Abstractions
{
    public interface IMediator
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }
}
