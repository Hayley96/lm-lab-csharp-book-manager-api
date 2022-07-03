using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApi.Models
{
	public class Author
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public string? Name { get; set; }
		//public ICollection<Book>? Books { get; set; }
	}
}