using System;

namespace Khairia.Core.Models
{
	public partial class Driversattendance
	{
		public short Attid { get; set; }
		public DateTime? Attdate { get; set; }
		public DateTime? Attdatetime { get; set; }
		public TimeSpan? Atttime { get; set; }
		public int? Groupid { get; set; }
	}
}