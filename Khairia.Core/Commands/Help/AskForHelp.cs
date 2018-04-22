using Khairia.Core.Models;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Help
{
	public class AskForHelp : IForm<AskForHelp.Request, AskForHelp.Response>
	{
		private readonly CoreDbContext _context;

		public AskForHelp(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			var help = new Help1(message.Corp, message.Money, message.Food, message.Name, message.Place, message.FamilyNumber,
				message.Income, message.Email, message.Notes, message.Status, message.Address, message.LivAllaw, message.Mobile,
				message.Rent, message.IncomeType, message.LivType, message.IdExpire, message.NId,message.Registerme);


			_context.Add(help);
			_context.SaveChanges();

			return new Response
			{
				Id = help.Helpid
			};
		}

		public class Request : IRequest<Response>
		{
			public string LivType { get; set; }
		    public int? Registerme { get; set; }
            public int? Corp { get; set; }
			public int? Money { get; set; }
			public int? Food { get; set; }
			public string Name { get; set; }
			public string Place { get; set; }
			public int? FamilyNumber { get; set; }
			public string Income { get; set; }
			public string Email { get; set; }
			public string Notes { get; set; }
			public int? Status { get; set; }
			public string Address { get; set; }
			public string LivAllaw { get; set; }
			public string Mobile { get; set; }
			public string Rent { get; set; }
			public string IncomeType { get; set; }
			public string IdExpire { get; set; }
			public string NId { get; set; }
		}

		public class Response
		{
			public int Id { get; set; }
		}
	}
}