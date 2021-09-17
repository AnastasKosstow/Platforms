using Mapster;
using PlatformService.Application.Models.Post;
using PlatformService.Infrastructure.Exceptions;
using PlatformService.Infrastructure.Validation;
using PlatformService.Mediator.Abstractions;
using PlatformService.Messaging;
using PlatformService.Messaging.Models;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Operations.Post
{
    public class CreatePlatformHandler : BaseHandler, IHandler<CreatePlatformRequestModel, CreatePlatformSuccessModel>
    {
        public CreatePlatformHandler(
            IAsyncRepository<Platform> asyncRepository,
            IMessageBusClient messageBusClient)
            : base(asyncRepository, messageBusClient)
        {
        }

        public async Task<CreatePlatformSuccessModel> HandleAsync(
            CreatePlatformRequestModel request, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<CreatePlatformRequestModel, InvalidRequestModelException>(request);

            var platform = AsyncRepository
                .Add(request.Adapt<Platform>());
            if (platform != null)
            {
                await AsyncRepository.CompleteAsync(cancellationToken);
            }

            var publishModel = platform.Adapt<PlatformPublishModel>();
            publishModel.Event = "Platform_Created";

            MessageBusClient?.Publish(publishModel);

            return await Task.FromResult(
                platform.Adapt<CreatePlatformSuccessModel>());
        }
    }
}
