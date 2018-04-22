using System;
using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Donation
{
	public class Donate : IForm<Donate.Request, Donate.Response>
	{
		private readonly CoreDbContext _context;

		public Donate(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			var donationsize = new Donationsize()
			{
				Ammont = message.Ammount,
				Donatename = message.DonateName
			};

			this._context.Donationsize.Add(donationsize);
			this._context.SaveChanges();


			return new Response();
		}

		public class Request : IRequest<Response>
		{
			public string DonateName { get; set; }
			public int? Ammount { get; set; }
			public string Mobile { get; set; }
		}

		public class Response
		{

		}
	}
}