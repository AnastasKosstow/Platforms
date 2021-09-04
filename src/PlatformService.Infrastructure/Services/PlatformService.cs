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
using Mapster;

namespace PlatformService.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IAsyncRepository<Platform> _asyncRepository;

        public PlatformService(
            IAsyncRepository<Platform> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        
        public async Task<GetPlatformsSuccessModel> Get(
            CancellationToken cancellationToken)
        {
            IEnumerable<PlatformModel> platforms = 
                (await _asyncRepository.All(cancellationToken))
                .Select(platform => platform.Adapt<PlatformModel>());

            return new GetPlatformsSuccessModel(platforms);
        }


        public async Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<CreatePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var platform = _asyncRepository
                .Add(requestModel.Adapt<Platform>());
            if (platform != null)
            {
                await _asyncRepository.CompleteAsync(cancellationToken);
            }

            return await Task.FromResult(
                platform.Adapt<CreatePlatformSuccessModel>());
        }


        public async Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<DeletePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var isDeleted = _asyncRepository.Remove(requestModel.Adapt<Platform>());
            if (isDeleted)
            {
                await _asyncRepository.CompleteAsync(cancellationToken);
            }

            return await Task.FromResult(
                new DeletePlatformSuccessModel(isDeleted));
        }
    }
}
