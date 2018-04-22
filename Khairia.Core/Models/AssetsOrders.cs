using System;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Khairia.Core.Models
{
	public class AssetsOrders
	{
		private AssetsOrders()
		{
		}

		public AssetsOrders(string square, string name, string mobile, string phone, string asset, string email, int? number,
			DateTime? day, string hour, string hallname, string address, string lat, string lon, int? stat, string notes,
			DateTime? recorddate)
		{
			Square = square;
			Name = name;
			Mobile = mobile;
			Phone = phone;
			Asset = asset;
			Email = email;
			Number = number;
			Day = day;
			Hour = hour;
			Hallname = hallname;
			Address = address;
			Lat = lat;
			Long = lon;
			Stat = stat;
			Notes = notes;
			Recoreddate = recorddate;
		}

		public short Assetorderid { get; private set; }
		public string Square { get; private set; }
		public string Name { get; private set; }
		public string Mobile { get; private set; }
		public string Phone { get; private set; }
		public string Email { get; private set; }
		public string Asset { get; private set; }
		public int? Number { get; private set; }
		public DateTime? Day { get; private set; }
		public string Hour { get; private set; }
		public DateTime? Recoreddate { get; private set; }
		public string Hallname { get; private set; }
		public string Address { get; private set; }
		public string Lat { get; private set; }
		public string Long { get; private set; }
		public int? Stat { get; private set; }
		public string Notes { get; private set; }
		public short? Driver { get; private set; }
		public DateTime? Approveddate { get; private set; }
		public DateTime? Canceldate { get; private set; }

		public void Approve()
		{
			Approveddate = DateTime.UtcNow;
		}

		public void Cancel()
		{
			Canceldate = DateTime.UtcNow;
		}
	}
}