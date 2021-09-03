using System.Collections.Generic;

namespace PlatformService.Application.Models.Get
{
    public class GetPlatformsSuccessModel
    {
        public GetPlatformsSuccessModel(IEnumerable<PlatformModel> platforms)
        {
            Platforms = platforms;
        }
        public IEnumerable<PlatformModel> Platforms { get; set; }
    }

    public class PlatformModel
    {
        public string Name { get; set; }

        public string Publisher { get; set; }
    }
}
