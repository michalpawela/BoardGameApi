using AutoMapper;
using Common.Dtos;
using DbManagement.Entities;

namespace Common
{
    public class BoardGameApiMappingProfile : Profile
    {
        public BoardGameApiMappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<GameDto, Game>();
            CreateMap<Game, GameDto>();

        }
    }
}
