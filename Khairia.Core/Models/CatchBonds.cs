using System;

namespace Khairia.Core.Models
{
	public partial class CatchBonds
	{
		public int Bondid { get; set; }
		public int? Userid { get; set; }
		public int? Sacrid { get; set; }
		public DateTime? Bonddate { get; set; }
	}
}