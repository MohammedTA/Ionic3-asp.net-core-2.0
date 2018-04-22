using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Items
{
	public class GetItems : IForm<GetItems.Request, GetItems.Response>
	{
		private readonly CoreDbContext _context;

		public GetItems(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response()
			{
				Items = _context.Items.Where(t=> !message.CategoryId.HasValue ||  t.Category == message.CategoryId).ToList()
			};
		}

		public class Request : IRequest<Response>
		{
			public int? CategoryId { get; set; }
		}

		public class Response
		{
			public IEnumerable<Models.Items> Items { get; set; }
		}
	}
}