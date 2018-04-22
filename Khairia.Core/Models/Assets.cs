using System;
using System.Text.RegularExpressions;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Khairia.Core.Models
{
	public class Assets
	{
		private Assets()
		{
		}

		public Assets(string name, string mobile, DateTime? day, string hour, string address, string lit, string lon,
			string phone, string square, string email,  int? assettype, short? assetdetails, string notes)
		{
			Name = name;
			Mobile = mobile;
			Day = day;
			Hour = GetHourNumber(hour);
			Address = address;
			Lit = lit;
			Long = lon;
			Phone = phone;
			Square = square;
			Email = email;
			Recorddate = DateTime.UtcNow;
			Assettype = assettype;
			Assetdetails = assetdetails;
			Notes = notes;
		}

	    private static int? GetHourNumber(string hour)
	    {
	        var resultString = Regex.Match(hour, @"\d+");
	        return int.Parse(resultString.Value);
	    }


	    public short Assetid { get; private set; }
		public string Name { get; private set; }
		public string Mobile { get; private set; }
		public DateTime? Day { get; private set; }
		public int? Hour { get; private set; }
		public string Address { get; private set; }
		public string Lit { get; private set; }
		public string Long { get; private set; }
		public string Square { get; private set; }
		public string Phone { get; private set; }
		public string Email { get; private set; }
		public DateTime? Recorddate { get; private set; }
		public int? Assettype { get; private set; }
		public short? Assetdetails { get; private set; }
		public int? Stat { get; private set; }
		public short? Driver { get; private set; }
		public DateTime? Approveddate { get; private set; }
		public DateTime? Canceldate { get; private set; }
		public string Notes { get; private set; }
		public short? Closed { get; private set; }
		public short? Approvuser { get; private set; }
		public short? Canceluser { get; private set; }
		public DateTime? Closedate { get; private set; }
	}
}