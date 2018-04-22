using System;

namespace Khairia.Core.Models
{
	public partial class Salaries
	{
		public short Salid { get; set; }
		public DateTime? Fromdate { get; set; }
		public DateTime? Todate { get; set; }
		public int? Satues { get; set; }
	}
}