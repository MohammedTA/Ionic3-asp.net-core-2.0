using System;

namespace Khairia.Core.Models
{
	public class Volunteerapp
	{
		private Volunteerapp()
		{
		}

		public Volunteerapp(string name, string nId, string mobile, string email, string address, string certificate,
			string skills, string days, string time, string hours, string workallaw, string fields, string nationality)
		{
			Name = name;
			Nid = nId;
			Mobile = mobile;
			Email = email;
			Address = address;
			Certifcates = certificate;
			Skils = skills;
			Dayes = days;
			Time = time;
			Houres = hours;
			Workallaw = workallaw;
			Fields = fields;
			Natinality = nationality;
			Date = DateTime.UtcNow;
		}

		public short Appid { get; private set; }
		public string Name { get; private set; }
		public string Nid { get; private set; }
		public string Mobile { get; private set; }
		public string Email { get; private set; }
		public string Address { get; private set; }
		public string Certifcates { get; private set; }
		public string Skils { get; private set; }
		public string Dayes { get; private set; }
		public string Time { get; private set; }
		public string Houres { get; private set; }
		public string Workallaw { get; private set; }
		public string Fields { get; private set; }
		public DateTime? Date { get; private set; }
		public string Natinality { get; private set; }
	}
}