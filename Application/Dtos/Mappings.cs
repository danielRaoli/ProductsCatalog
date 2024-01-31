using AutoMapper;
using CatalogoDeProdutos.Models;

namespace ProductsCatalog.Application.Dtos
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, Categorydto> ().ReverseMap();
            CreateMap<Product, ProductDto> ().ReverseMap(); 
        }
    }
}
