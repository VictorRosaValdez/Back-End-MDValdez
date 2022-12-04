using AutoMapper;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Models;

namespace MDValdez.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Product, ProductReadDTO>();

            // Mappinng from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ProductCreateDTO, Product>().ReverseMap();

            // Mapping from the updateDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Product, ProductDeleteDTO>();
            

        }

    }
}
