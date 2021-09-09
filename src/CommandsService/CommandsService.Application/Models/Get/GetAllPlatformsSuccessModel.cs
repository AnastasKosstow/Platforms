using System.Collections.Generic;

namespace CommandsService.Application.Models.Get
{
    public record GetAllPlatformsSuccessModel
    {
        public GetAllPlatformsSuccessModel(IEnumerable<PlatformModel> platforms)
        {
            Platforms = platforms;
        }
        public IEnumerable<PlatformModel> Platforms { get; set; }
    }

    public record PlatformModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
