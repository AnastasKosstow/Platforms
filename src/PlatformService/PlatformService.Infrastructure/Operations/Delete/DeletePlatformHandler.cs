using Mapster;
using PlatformService.Application.Models.Delete;
using PlatformService.Infrastructure.Exceptions;
using PlatformService.Infrastructure.Validation;
using PlatformService.Mediator.Abstractions;
using PlatformService.Messaging;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Operations.Delete
{
    public class DeletePlatformHandler : BaseHandler, IHandler<DeletePlatformRequestModel, DeletePlatformSuccessModel>
    {
        public DeletePlatformHandler(
            IAsyncRepository<Platform> asyncRepository,
            IMessageBusClient messageBusClient)
            : base(asyncRepository, messageBusClient)
        {
        }

        public async Task<DeletePlatformSuccessModel> HandleAsync(
            DeletePlatformRequestModel request,
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<DeletePlatformRequestModel, InvalidRequestModelException>(request);

            var isDeleted = AsyncRepository.Remove(request.Adapt<Platform>());
            if (isDeleted)
            {
                await AsyncRepository.CompleteAsync(cancellationToken);
            }

            // TODO: Send Event to RabbitMQ

            return await Task.FromResult(
                new DeletePlatformSuccessModel(isDeleted));
        }
    }
}
