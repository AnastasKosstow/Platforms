﻿using PlatformService.Mediator.Abstractions;

namespace PlatformService.Application.Models.Get
{
    public record GetPlatformsRequestModel : IRequest<GetPlatformsSuccessModel>
    {
        public int Id { get; set; }
    }
}
