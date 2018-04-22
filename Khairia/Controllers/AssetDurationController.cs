using System.Collections.Generic;
using Khairia.Core.Commands.AssetDuration;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
    [Route("api/AssetDuration")]
    public class AssetDurationController : Controller
    {
        private readonly IMediator _mediator;

        public AssetDurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<AssetDuration> Get()
        {
            return _mediator.Send(new GetAssetDuration.Request()).Result.AssetDurations;
        }
    }
}