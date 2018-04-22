using System;

namespace Khairia.Core.Models
{
	public partial class Newstable
	{
		public short Id { get; set; }
		public string Image { get; set; }
		public string Detail { get; set; }
		public string Title { get; set; }
		public int? Active { get; set; }
		public DateTime? Expire { get; set; }
	}
}