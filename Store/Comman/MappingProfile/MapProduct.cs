using AutoMapper;
using Store.DTO.Products;
using Store.Model;

namespace Store.Comman.MapProfile
{
	public class MapProduct : Profile
	{
        public MapProduct()
        {
            CreateMap<ProductsDTO, ProductsModel>();
        }
    }
}
