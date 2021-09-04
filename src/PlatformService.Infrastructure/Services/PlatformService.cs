using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;
using PlatformService.Application.Models.Put;
using PlatformService.Infrastructure.Validation;
using PlatformService.Infrastructure.Exceptions;
using PlatformService.Persistence;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories.Abstractions;
using PlatformService.Persistence.UnitOfWork;
using Mapster;

namespace PlatformService.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IAsyncReadOnlyRepository<Platform> _readOnlyRepository;
        private readonly IDeletionRepository<Platform> _deletionRepository;
        private readonly IInsertionRepository<Platform> _insertionRepository;
        private readonly IAsyncUnitOfWork<ApplicationDbContext> _unitOfWork;

        public PlatformService(
            IAsyncReadOnlyRepository<Platform> readOnlyRepository,
            IDeletionRepository<Platform> deletionRepository,
            IInsertionRepository<Platform> insertionRepository,
            IAsyncUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _readOnlyRepository = readOnlyRepository;
            _deletionRepository = deletionRepository;
            _insertionRepository = insertionRepository;
            _unitOfWork = unitOfWork;
        }

        
        public async Task<GetPlatformsSuccessModel> Get(
            CancellationToken cancellationToken)
        {
            IEnumerable<PlatformModel> platforms = 
                (await _readOnlyRepository.All(cancellationToken))
                .Select(platform => platform.Adapt<PlatformModel>());

            return new GetPlatformsSuccessModel(platforms);
        }


        public async Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<CreatePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var platform = _insertionRepository
                .Add(requestModel.Adapt<Platform>());
            if (platform != null)
            {
                await _unitOfWork.CompleteAsync(cancellationToken);
            }

            return await Task.FromResult(
                platform.Adapt<CreatePlatformSuccessModel>());
        }


        public async Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel, 
            CancellationToken cancellationToken)
        {
            Guard.AgainstInvalidModel<DeletePlatformRequestModel, InvalidRequestModelException>(requestModel);

            var isDeleted = _deletionRepository.Remove(requestModel.Adapt<Platform>());
            if (isDeleted)
            {
                await _unitOfWork.CompleteAsync(cancellationToken);
            }

            return await Task.FromResult(
                new DeletePlatformSuccessModel(isDeleted));
        }
    }
}
