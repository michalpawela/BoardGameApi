using AutoMapper;
using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.DbManagement.Entities;

namespace BoardGame_REST_API
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
