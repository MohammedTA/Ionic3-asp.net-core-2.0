using System.Collections.Generic;
using Khairia.Core.Commands.Categories;
using Khairia.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Khairia.Controllers
{
	[Route("api/Categories")]
	public class CategoriesController : Controller
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public IEnumerable<Categories> Get()
		{
			return _mediator.Send(new GetCategories.Request()).Result.Categories;
		}
	}
}