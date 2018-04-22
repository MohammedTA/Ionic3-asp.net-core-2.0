using System;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Khairia.Core.Models
{
	public class Help1
	{
		public Help1(int? corp, int? money, int? food, string name, string place, int? familynumber,
			string income, string email, string notes, int? statues, string address, string livallaw,
			string mobile, string rent, string incometype, string livtype, string idexpire, string nid, int? registerMe)
		{
			Registerme = 0;
			Corp = corp;
			Money = money;
			Food = food;
			Name = name;
			Place = place;
			Familynumber = familynumber;
			Income = income;
			Email = email;
			Notes = notes;
			Statues = statues;
			Address = address;
			Livallaw = livallaw;
			Mobile = mobile;
			Rent = rent;
			Incometype = incometype;
			Livtype = livtype;
			Idexpire = idexpire;
			Nid = nid;
		    Registerme = registerMe;

            Orderdate = DateTime.UtcNow;
		}

		public short Helpid { get; private set; }
		public int? Registerme { get; private set; }
		public int? Corp { get; private set; }
		public int? Money { get; private set; }
		public int? Food { get; private set; }
		public string Name { get; private set; }
		public string Place { get; private set; }
		public int? Familynumber { get; private set; }
		public string Income { get; private set; }
		public string Email { get; private set; }
		public string Notes { get; private set; }
		public int? Statues { get; private set; }
		public DateTime? Orderdate { get; private set; }
		public string Address { get; private set; }
		public string Mobile { get; private set; }
		public string Livallaw { get; private set; }
		public string Rent { get; private set; }
		public string Incometype { get; private set; }
		public string Livtype { get; private set; }
		public string Idexpire { get; private set; }
		public string Nid { get; private set; }
	}
}