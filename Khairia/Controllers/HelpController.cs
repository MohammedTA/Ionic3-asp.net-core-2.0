using System.Threading.Tasks;
using Khairia.Core.Commands.Help;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/Help")]
	public class HelpController : Controller
	{
		private readonly IMediator _mediator;

		public HelpController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<AskForHelp.Response> Post([FromBody] AskForHelp.Request request)
		{
		    return await _mediator.Send(request);
		}
	}
}