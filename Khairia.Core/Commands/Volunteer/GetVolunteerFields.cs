using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Volunteer
{
	public class GetVolunteerFields : IForm<GetVolunteerFields.Request, GetVolunteerFields.Response>
	{
		private readonly CoreDbContext _context;

		public GetVolunteerFields(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			return new Response
			{
				Fields = _context.Volunteerfields.ToList()
			};
		}

		public class Response
		{
			public IEnumerable<Volunteerfields> Fields { get; set; }
		}

		public class Request : IRequest<Response>
		{
		}
	}
}