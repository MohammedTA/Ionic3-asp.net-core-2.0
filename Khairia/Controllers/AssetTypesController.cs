using System.Collections.Generic;
using Khairia.Core.Commands.Assets;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
    [Route("api/AssetTypes")]
    public class AssetTypesController : Controller
    {
        private readonly IMediator _mediator;

        public AssetTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<Assetstypes> Get()
        {
            return _mediator.Send(new GetAssetsTypes.Request()).Result.Types;
        }
    }
}