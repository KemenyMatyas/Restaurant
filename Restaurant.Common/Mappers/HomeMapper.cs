namespace Restaurant.Common.Mappers;

using Data.Dtos;
using Data.Models;
using Data.Models.ManyToMany;
using global::AutoMapper;

public class HomeMapper : Profile
{
    public HomeMapper()
    {
        CreateMap<MenuItem, MenuItemDto>().ForMember(dto => dto.Ingredients, m => 
            m.MapFrom(i => i.Ingredients));

        CreateMap<IngredientMenuItem, IngredientDto>()
            .ForMember(dto => dto.Name, m =>
            m.MapFrom(i => i.Ingredient.Name))
            .ForMember(dto => dto.Guid, m =>
                m.MapFrom(i => i.Ingredient.Guid));

        CreateMap<Category, CategoryDto>().ReverseMap();

    }
}