using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Assets
{
	public class GetAssetsTypes : IForm<GetAssetsTypes.Request, GetAssetsTypes.Response>
	{
		private readonly CoreDbContext _context;

		public GetAssetsTypes(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response
			{
			    Types = _context.Assetstypes.ToList()
			};
		}

		public class Response
		{
			public IEnumerable<Assetstypes> Types { get; set; }
		}

		public class Request : IRequest<Response>
		{
		}
	}
}