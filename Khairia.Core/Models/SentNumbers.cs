using System;

namespace Khairia.Core.Models
{
	public partial class SentNumbers
	{
		public short Id { get; set; }
		public string Number { get; set; }
		public string Message { get; set; }
		public int? Type { get; set; }
		public DateTime? Date { get; set; }
	}
}