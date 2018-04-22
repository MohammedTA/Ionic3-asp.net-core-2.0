using System.Collections.Generic;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace Khairia.Core.Commands.Volunteer
{
	public class AddVolunteer : IForm<AddVolunteer.Request, AddVolunteer.Response>
	{
		private readonly CoreDbContext _context;

		public AddVolunteer(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			var volunteerapp = new Volunteerapp(message.Name,
                message.NId,
                message.Mobile,
                message.Email,
				message.Address,
                message.Certifcates,
                message.Skils,
                string.Join(", ", message.Days),
				message.Time,
                message.Houres,
                message.Workallaw,
			    string.Join(", ", message.Fields),
                message.Natinality);
			_context.Volunteerapp.Add(volunteerapp);
			_context.SaveChanges();

			return new Response
			{
				Id = volunteerapp.Appid
			};
		}

		public class Response
		{
			public short Id;
		}

		public class Request : IRequest<Response>
		{
			public string Address { get; set; }
			public string Certifcates { get; set; }
			public List<string> Days { get; set; }
			public string Email { get; set; }
			public List<string> Fields { get; set; }
			public string Houres { get; set; }
			public string Mobile { get; set; }
			public string Name { get; set; }
			public string NId { get; set; }
			public string Skils { get; set; }
			public string Time { get; set; }
			public string Workallaw { get; set; }
			public string Natinality { get; set; }
		}
	}
}