using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Models;

namespace MDValdez.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Customer, AccountReadDTO>();

            // Mappinng from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<AccountCreateDTO, Customer>().ReverseMap();

            // Mapping from the updateDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<AccountUpdateDTO, Customer>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Customer, AccountDeleteDTO>();


        }
    }
}
