using System;

namespace Khairia.Core.Models
{
	public partial class Offdayes
	{
		public short Id { get; set; }
		public DateTime? Frmdate { get; set; }
		public DateTime? Todate { get; set; }
	}
}