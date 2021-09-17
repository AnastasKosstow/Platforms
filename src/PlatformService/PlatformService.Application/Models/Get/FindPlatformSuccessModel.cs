using PlatformService.Application.Models.Common;

namespace PlatformService.Application.Models.Get
{
    public record FindPlatformSuccessModel
    {
        public FindPlatformSuccessModel(PlatformModel platforms)
        {
            Platforms = platforms;
        }
        public PlatformModel Platforms { get; set; }
    }
}

