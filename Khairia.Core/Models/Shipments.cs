using System;

namespace Khairia.Core.Models
{
	public partial class Shipments
	{
		public short Shipid { get; set; }
		public int? Shipnumber { get; set; }
		public DateTime? Shipdate { get; set; }
		public string Shipname { get; set; }
		public string Shipmobile { get; set; }
	}
}