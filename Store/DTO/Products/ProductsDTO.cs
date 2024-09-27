using System.ComponentModel.DataAnnotations;

namespace Store.DTO.Products
{
	public class ProductsDTO
	{
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
	}
}
