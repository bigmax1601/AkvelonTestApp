using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkvelonTestApp.Data.Models
{
	[Table("Users")]
	public class UserModel
	{
		[Key]
		[Required]
		[Display(Description = "Nick Name")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid NickName")]
		public virtual string NickName { get; set; }

		[Required]
		[Display(Description = "Full Name")]
		public virtual string FullName { get; set; }
	}
}