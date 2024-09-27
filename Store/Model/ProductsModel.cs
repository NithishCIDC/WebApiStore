using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
	public class ProductsModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
	}
}
