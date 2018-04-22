using System.Threading.Tasks;
using Khairia.Core.Commands.Neddy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/Needy")]
	public class NeedyController : Controller
	{
		private readonly IMediator _mediator;

		public NeedyController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<AddNeedy.Response> Post(AddNeedy.Request request)
		{
			return await _mediator.Send(request);
		}
	}
}