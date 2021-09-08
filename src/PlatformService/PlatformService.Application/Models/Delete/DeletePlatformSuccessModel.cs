
namespace PlatformService.Application.Models.Delete
{
    public record DeletePlatformSuccessModel
    {
        public DeletePlatformSuccessModel(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public bool IsDeleted { get; set; }
    }
}
