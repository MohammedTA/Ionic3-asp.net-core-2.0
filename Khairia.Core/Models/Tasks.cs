namespace Khairia.Core.Models
{
	public partial class Tasks
	{
		public short Stratgyid { get; set; }
		public string Straname { get; set; }
		public int? Number { get; set; }
		public string Cost { get; set; }
		public string Start { get; set; }
		public string Enddate { get; set; }
		public short? Targetid { get; set; }
		public short? Unitid { get; set; }
		public string Employees { get; set; }
		public string Superviser { get; set; }
		public string Empsvalue { get; set; }
		public string Supervalues { get; set; }
	}
}