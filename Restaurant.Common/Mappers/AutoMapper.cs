namespace Restaurant.Common.Mappers;

using Data.Models;
using FTBHungary.Data.Dtos;
using global::AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<User, RegisterUserDto>().ReverseMap();
    }
}