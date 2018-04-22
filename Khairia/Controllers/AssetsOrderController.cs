using System;
using System.Threading.Tasks;
using Khairia.Core.Commands.AssetsOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/AssetsOrder")]
	public class AssetsOrderController : Controller
	{
		private readonly IMediator _mediator;

		public AssetsOrderController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<AddAssetsOrder.Response> Post([FromBody] AddAssetsOrder.Request data)
		{
			return await _mediator.Send(data);
		}
	}
}