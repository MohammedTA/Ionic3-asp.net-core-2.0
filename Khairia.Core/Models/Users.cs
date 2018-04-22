namespace Khairia.Core.Models
{
	public partial class Users
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int? Roleid { get; set; }
		public string Userfullname { get; set; }
		public string Userphone { get; set; }
	}
}