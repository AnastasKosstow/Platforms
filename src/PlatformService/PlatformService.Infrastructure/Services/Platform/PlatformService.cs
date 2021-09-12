using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;
using PlatformService.Infrastructure.Validation;
using PlatformService.Infrastructure.Exceptions;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using PlatformService.Messaging;
using PlatformService.Messaging.Models;
using Mapster;

namespace PlatformService.Infrastructure.Services
{
    public class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(
            IAsyncRepository<Platform> asyncRepository,
            IMessageBusClient messageBusClient)
            : base(asyncRepository, messageBusClient)
        {
        }

        public async Task<GetPlatformsSuccessModel> Get(
            CancellationToken cancellationToken)
        {
            IEnumerable<PlatformModel> platforms = 
                (await AsyncRepository.All(cancellationToken))
                .Select(platform => platform.Adapt<PlatformModel>());

            return new GetPlatformsSuccessModel(platforms);
        }


        public async Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<CreatePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var platform = AsyncRepository
                .Add(requestModel.Adapt<Platform>());
            if (platform != null)
            {
                await AsyncRepository.CompleteAsync(cancellationToken);
            }

            var publishModel = platform.Adapt<PlatformPublishModel>();
            publishModel.Event = "Platform_Created";

            MessageBusClient.Publish(publishModel);

            return await Task.FromResult(
                platform.Adapt<CreatePlatformSuccessModel>());
        }


        public async Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<DeletePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var isDeleted = AsyncRepository.Remove(requestModel.Adapt<Platform>());
            if (isDeleted)
            {
                await AsyncRepository.CompleteAsync(cancellationToken);
            }

            return await Task.FromResult(
                new DeletePlatformSuccessModel(isDeleted));
        }
    }
}
