using System;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.AssetsOrder
{
	public class AddAssetsOrder : IForm<AddAssetsOrder.Request, AddAssetsOrder.Response>
	{
		private readonly CoreDbContext _context;

		public AddAssetsOrder(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			var assetsOrder = new AssetsOrders(message.Square, message.Name, message.Mobile, message.Phone, message.Asset,
				message.Email, message.Number, message.Day, message.Hour, message.Hallname, message.Address, message.Lat,
				message.Long, message.Stat, message.Notes, message.Recoreddate);

		    //this.EnsureInWeekDays(assetsOrder);
		    //this.EnsureNotInDayOff(assetsOrder);
            EnsureAvailableResources(assetsOrder, message.Code);


			_context.AssetsOrders.Add(assetsOrder);
			_context.SaveChanges();



			new SmsService().Send("تم استلام طلبكم بتاريختم استلام طلبكم لحفظ النعمة", message.Mobile);



			return new Response
			{
				Id = assetsOrder.Assetorderid
			};
		}

	    private void EnsureInWeekDays(Models.AssetsOrders assetsOrders)
	    {
	        if (!assetsOrders.Day.HasValue)
	        {
	            throw new BusinessException("رجاءا أدخل التاريخ");
	        }

	        if (!this._context.Weekdayes.Any(t =>
	            t.Name.Equals(assetsOrders.Day.Value.DayOfWeek.ToString(), StringComparison.OrdinalIgnoreCase) &&
	            t.State != 0))
	        {
	            throw new BusinessException("اليوم الذي تم اختياره يوم عطلة");
	        }
	    }

	    private void EnsureNotInDayOff(Models.AssetsOrders assetsOrders)
	    {
	        if (!assetsOrders.Day.HasValue)
	        {
	            throw new BusinessException("رجاءا أدخل التاريخ");
	        }

	        if (this._context.Offdayes.Any(t => (assetsOrders.Day.Value >= t.Frmdate && 
            assetsOrders.Day.Value <= t.Todate)
	                                            || assetsOrders.Day.Value == t.Frmdate.Value
	                                            || assetsOrders.Day.Value == t.Todate.Value
	        ))
	        {
	            throw new BusinessException("اليوم الذي تم اختياره يوم عطلة");
	        }
	    }

        private void EnsureAvailableResources(AssetsOrders assetsOrder, int duCode)
		{
			var count = _context.AssetsOrders.Count(t => t.Day == assetsOrder.Day && 
            t.Hour == assetsOrder.Hour &&
            t.Stat != 2) + 1;

		    if (_context.Durations.Any(t => t.Code.Value == duCode && t.Count < count))
		    {
		        throw new BusinessException(
		            "عذراً، طاقتنا الاستيعابية لا تسمح بإستقبال طلبات أخرى في هذا التوقيت من اليوم، يرجى اختيار وقت آخر .");
		    }
		}


		public class Response
		{
			public int Id { get; set; }
		}

		public class Request : IRequest<Response>
		{
			public string Square { get; set; }
			public string Name { get; set; }
			public string Mobile { get; set; }
			public string Phone { get; set; }
			public string Email { get; set; }
			public string Asset { get; set; }
			public int? Number { get; set; }
			public DateTime? Day { get; set; }
			public string Hour { get; set; }
            public DateTime? Recoreddate { get; set; }
			public string Hallname { get; set; }
			public string Address { get; set; }
			public string Lat { get; set; }
			public string Long { get; set; }
			public int? Stat { get; set; }
			public string Notes { get; set; }
			public int Code { get; set; }
		}
	}
}