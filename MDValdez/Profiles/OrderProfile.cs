using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Models;

namespace MDValdez.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Order, OrderReadDTO>();

            // Mappinng from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<OrderCreateDTO, Order>().ReverseMap();

            // Mapping from the updateDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<OrderUpdateDTO, Order>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Order, OrderDeleteDTO>();


        }
    }
}
