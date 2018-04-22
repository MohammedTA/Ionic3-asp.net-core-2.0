using System;

namespace Khairia.Core.Models
{
	public partial class Sacrifinames
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Mobile { get; set; }
		public string Gender { get; set; }
		public int? SacrifiNumber { get; set; }
		public string Booknumber { get; set; }
		public int? Statues { get; set; }
		public DateTime? Date { get; set; }
		public TimeSpan? Time { get; set; }
		public string Place { get; set; }
		public string Mail { get; set; }
		public int? Paytype { get; set; }
	}
}