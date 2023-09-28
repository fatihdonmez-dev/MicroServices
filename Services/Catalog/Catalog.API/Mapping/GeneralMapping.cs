using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Models;

namespace Catalog.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Feature, FeatureDto>().ReverseMap();

        }

    }
}
