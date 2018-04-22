using System;

namespace Khairia.Core.Models
{
	public partial class Help2
	{
		public short Helpid { get; set; }
		public int? Recid { get; set; }
		public string Helptype { get; set; }
		public string Helpnotes { get; set; }
		public string Things { get; set; }
		public int? Statues { get; set; }
		public DateTime? Date { get; set; }
	}
}