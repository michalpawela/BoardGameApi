using AutoMapper;
using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.DbManagement.Entities;

namespace BoardGame_REST_API
{
    public class BoardGameApiMappingProfile : Profile
    {
        public BoardGameApiMappingProfile()
        {
            // Mapping for Author -> AuthorDto
            CreateMap<Author, AuthorDto>()
               .ForMember(dest => dest.AuthorGame, opt => opt.MapFrom(src => src.AuthorGames));

            // Mapping for Game -> GameDto
            CreateMap<GameDto, Game>();

            // Mapping for AuthorGame -> AuthorGameDto
            CreateMap<AuthorGame, AuthorGameDto>()
               .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
               .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game));

            // Mapping for Game -> GameDto
            CreateMap<Game, GameDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.AuthorGames.Select(ag => ag.Author)))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CategoryGames.Select(cg => cg.Category)));

        }
    }
}
