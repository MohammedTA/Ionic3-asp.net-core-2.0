using System.Collections.Generic;
using Khairia.Core.Commands.Volunteer;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/VolunteerFields")]
	public class VolunteerFieldsController : Controller
	{
		private readonly IMediator _mediator;

		public VolunteerFieldsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public IEnumerable<Volunteerfields> Get()
		{
			return _mediator.Send(new GetVolunteerFields.Request()).Result.Fields;
		}
	}
}