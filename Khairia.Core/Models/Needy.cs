// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Khairia.Core.Models
{
	public class Needy
	{
		public Needy(short? statues, string senderphone, string sendername, string squer, string phone, string pername)
		{
			Statues = statues;
			Senderphone = senderphone;
			Sendername = sendername;
			Squer = squer;
			Phone = phone;
			Pername = pername;
		}

		public short Id { get; private set; }
		public string Pername { get; private set; }
		public string Phone { get; private set; }
		public string Squer { get; private set; }
		public string Sendername { get; private set; }
		public string Senderphone { get; private set; }
		public short? Statues { get; private set; }
	}
}