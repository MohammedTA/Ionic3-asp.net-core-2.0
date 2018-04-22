using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.AssetOrderDuration
{
	public class GetAssetOrderDuration : IForm<GetAssetOrderDuration.Request, GetAssetOrderDuration.Response>
	{
		private readonly CoreDbContext _context;

		public GetAssetOrderDuration(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response()
			{
			    Durations = _context.Durations.ToList()
			};
		}

		public class Request : IRequest<Response>
		{
		}

		public class Response
		{
			public IEnumerable<Models.Durations> Durations { get; set; }
		}
	}
}