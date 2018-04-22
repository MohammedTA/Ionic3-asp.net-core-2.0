using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Neddy
{
	public class AddNeedy : IForm<AddNeedy.Request, AddNeedy.Response>
	{
		private readonly CoreDbContext _context;

		public AddNeedy(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			var needy = new Needy(message.Statues, message.Senderphone, message.Sendername, message.Squer, message.Phone,
				message.Pername);

			_context.Needy.Add(needy);
			_context.SaveChanges();
			return new Response();
		}

		public class Response
		{
		}

		public class Request : IRequest<Response>
		{
			public string Pername { get; set; }
			public string Phone { get; set; }
			public string Squer { get; set; }
			public string Sendername { get; set; }
			public string Senderphone { get; set; }
			public short? Statues { get; set; }
		}
	}
}