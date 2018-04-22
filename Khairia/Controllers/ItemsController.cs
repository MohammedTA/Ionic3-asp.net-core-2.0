using System.Collections.Generic;
using Khairia.Core.Commands.Items;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/Items")]
	public class ItemsController : Controller
	{
		private readonly IMediator _mediator;

		public ItemsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		public IEnumerable<Items> Get([FromQuery]int? categoryId)
		{
			return _mediator.Send(new GetItems.Request
			{
				CategoryId = categoryId
            }).Result.Items;
		}
	}
}