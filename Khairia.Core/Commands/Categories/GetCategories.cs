using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Categories
{
	public class GetCategories : IForm<GetCategories.Request, GetCategories.Response>
	{
		private readonly CoreDbContext _context;

		public GetCategories(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response()
			{
				Categories = _context.Categories.ToList()
			};
		}

		public class Request : IRequest<Response>
		{
		}

		public class Response
		{
			public IEnumerable<Models.Categories> Categories { get; set; }
		}
	}
}