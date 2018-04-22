using System.Collections.Generic;
using Khairia.Core.Commands.AssetDuration;
using Khairia.Core.Commands.AssetOrderDuration;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
    [Route("api/AssetOrderDuration")]
    public class AssetOrderDurationController : Controller
    {
        private readonly IMediator _mediator;

        public AssetOrderDurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<Durations> Get()
        {
            return _mediator.Send(new GetAssetOrderDuration.Request()).Result.Durations;
        }
    }
}