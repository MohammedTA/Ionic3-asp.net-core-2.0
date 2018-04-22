using System;
using System.Collections.Generic;
using System.Linq;
using Khairia.Core.Models;
using Khairia.Infrastructure;
using Khairia.Infrastructure.Forms;
using MediatR;

namespace Khairia.Core.Commands.Assets
{
	public class AddAssests : IForm<AddAssests.Request, AddAssests.Response>
	{
		private readonly CoreDbContext _context;

		public AddAssests(CoreDbContext context)
		{
			_context = context;
		}

		public Response Handle(Request message)
		{
			
			var assets = new Models.Assets(message.Name, message.Mobile, message.Day, message.Hour, message.Address,
				message.Lat, message.Lon, message.Phone, message.Square, message.Email, message.AssetType, message.Details,
				message.Notes);

		    this.EnsureInWeekDays(assets);
		    this.EnsureNotInDayOff(assets);
            this.EnsureAvailableResources(assets, message.DuCode);


			foreach (var item in message.Items)
			{
				_context.Assetitems.Add(new Assetitems
				{
					Assetid = assets.Assetid,
					Assetname = item.AssetName,
					Assetnumber = item.AssetNumber,
					Notes = item.Note
				});
			}
			_context.Assets.Add(assets);
			_context.SaveChanges();


			new SmsService().Send($"تم استلام طلبكم بتاريخ {message.Day.Value.ToShortDateString()} لبرنامج جلب الاثاث يشترط في استلام التبرعات ان تكون مفككة وجاهزة للتحميل وذلك لسرعة خدمتكم ولكم فائق الشكر", message.Mobile);


			return new Response
			{
				Id = assets.Assetid
			};
		}

		private void EnsureInWeekDays(Models.Assets assets)
		{
			if (!assets.Day.HasValue)
			{
				throw new BusinessException("رجاءا أدخل التاريخ");
			}

			if (!this._context.Weekdayes.Any(t =>
				t.Name.Equals(assets.Day.Value.DayOfWeek.ToString(), StringComparison.OrdinalIgnoreCase) &&
			    t.State != 0))
			{
				throw new BusinessException("اليوم الذي تم اختياره يوم عطلة");
			}
		}

		private void EnsureNotInDayOff(Models.Assets assets)
		{
			if (!assets.Day.HasValue)
			{
				throw new BusinessException("رجاءا أدخل التاريخ");
			}

			if (this._context.Offdayes.Any(t => (assets.Day.Value>= t.Frmdate && assets.Day.Value <= t.Todate )
				|| assets.Day.Value == t.Frmdate.Value
				|| assets.Day.Value == t.Todate.Value
				))
			{
				throw new BusinessException("اليوم الذي تم اختياره يوم عطلة");
			}
		}

		private void EnsureAvailableResources(Models.Assets assets,int duCode)
		{
			var count = this._context.Assets.Count(t => t.Day == assets.Day && 
            t.Hour == assets.Hour && 
            t.Stat != 2) + 1;

			if (this._context.AssetDuration.Any(t => t.Durcode.Value == duCode && t.Durcount < count))
			{
				throw new BusinessException("عذراً، طاقتنا الاستيعابية لا تسمح بإستقبال طلبات أخرى في هذا التوقيت من اليوم، يرجى اختيار وقت آخر .");
			}
		}



		public class Response
		{
			public short Id { get; set; }
		}

		public class Request : IRequest<Response>
		{
			public string Name { get; set; }
			public string Mobile { get; set; }
			public DateTime? Day { get; set; }
			public string Hour { get; set; }
			public string Address { get; set; }
			public string Lat { get; set; }
			public string Lon { get; set; }
			public string Phone { get; set; }
			public string Square { get; set; }
			public string Email { get; set; }
			public int? AssetType { get; set; }
			public short? Details { get; set; }
			public string Notes { get; set; }
			public int DuCode { get; set; }

			public List<Assetitem> Items { get; set; }
		}

	    public class Assetitem
	    {
	        public string AssetName { get;set; }
	        public int AssetNumber { get;set; }
	        public string Note { get;set; }
        }

    }
}