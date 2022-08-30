namespace Restaurant.Common.Mappers;

using Data.Dtos;
using Data.Models;
using global::AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<User, RegisterUserDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}