namespace Khairia.Core.Models
{
	public partial class Marquee
	{
		public short Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }
		public int? Active { get; set; }
	}
}