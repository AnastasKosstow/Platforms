
namespace PlatformService.Application.Models.Delete
{
    public class  DeletePlatformSuccessModel
    {
        public DeletePlatformSuccessModel(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public bool IsDeleted { get; set; }
    }
}
