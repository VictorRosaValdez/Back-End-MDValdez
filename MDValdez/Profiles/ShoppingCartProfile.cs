using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Models;

namespace MDValdez.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<ShoppingCart, ShoppingCartReadDTO>();

            // Mappinng from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ShoppingCartCreateDTO, ShoppingCart>().ReverseMap();

            // Mapping from the updateDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ShoppingCartUpdateDTO, ShoppingCart>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<ShoppingCart, ShoppingCartDeleteDTO>();


        }
    }
}
