using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.DTO.Products;
using Store.Model;

namespace Store.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public ProductsController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<IEnumerable<ProductsModel>> GetAll()
		{
			var List = _dbContext.Products.ToList();
			if (List is not null)
			{
				return Ok(List);
			}
			return NoContent();
		}

		[HttpGet("{id:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<ProductsModel> GetById(Guid id)
		{
			var pro = _dbContext.Products.Find(id)!;
			if (pro is not null)
			{
				return Ok(pro);
			}
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<ProductsDTO>> Create([FromBody] ProductsDTO productsdto)
		{
			ProductsModel products = new ProductsModel()
			{
				Name = productsdto.Name,
				Description = productsdto.Description,
			};
			await _dbContext.Products.AddAsync(products);
			await _dbContext.SaveChangesAsync();
			return CreatedAtAction("GetById",new {Id=products.Id },products);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Update([FromBody] ProductsModel products)
		{
			var response = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == products.Id);
			if (response is not null)
			{
				_dbContext.Products.Update(products);
				await _dbContext.SaveChangesAsync();
				return Ok();
			}
			return NotFound();
		}

		[HttpDelete("{id:Guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductsModel>> Delete(Guid id)
		{
			var product = _dbContext.Products.Find(id);
			if (product is not null)
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
				return Ok();
			}
			return NotFound();
		}
	}
}
