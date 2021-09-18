using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Mediator.Abstractions
{
    public interface IHandler<in TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
