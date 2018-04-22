using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Khairia.Core.Commands.Volunteer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/[controller]")]
	public class VolunteerController : Controller
	{
		private readonly IMediator _mediator;

		public VolunteerController(IMediator mediator)
		{
			_mediator = mediator;
		}


		// POST api/volanteer
		[HttpPost]
		public async Task<AddVolunteer.Response> Post([FromBody] AddVolunteer.Request request)
		{
			return await _mediator.Send(request);
		}
	}
}