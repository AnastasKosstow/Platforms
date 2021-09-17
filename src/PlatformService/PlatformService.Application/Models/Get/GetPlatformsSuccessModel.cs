using PlatformService.Application.Models.Common;
using System.Collections.Generic;

namespace PlatformService.Application.Models.Get
{
    public record GetPlatformsSuccessModel
    {
        public GetPlatformsSuccessModel(IEnumerable<PlatformModel> platforms)
        {
            Platforms = platforms;
        }
        public IEnumerable<PlatformModel> Platforms { get; set; }
    }
}
