using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.AssetDuration
{
	public class GetAssetDuration : IForm<GetAssetDuration.Request, GetAssetDuration.Response>
	{
		private readonly CoreDbContext _context;

		public GetAssetDuration(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response()
			{
			    AssetDurations = _context.AssetDuration.ToList()
			};
		}

		public class Request : IRequest<Response>
		{
		}

		public class Response
		{
			public IEnumerable<Models.AssetDuration> AssetDurations { get; set; }
		}
	}
}