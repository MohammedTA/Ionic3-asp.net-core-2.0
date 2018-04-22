using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Khairia.Core.Commands.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/[controller]")]
	public class AssetsController: Controller
	{
		private readonly IMediator _mediator;

		public AssetsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<AddAssests.Response> Post([FromBody] AddAssests.Request assests)
		{
			return await this._mediator.Send(assests);
		}

	}
}
