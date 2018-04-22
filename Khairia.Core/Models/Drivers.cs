namespace Khairia.Core.Models
{
	public partial class Drivers
	{
		public short Driverid { get; set; }
		public string Drivername { get; set; }
		public string Mobile { get; set; }
		public int? Category { get; set; }
		public int? Type { get; set; }
		public int? Groupid { get; set; }
	}
}