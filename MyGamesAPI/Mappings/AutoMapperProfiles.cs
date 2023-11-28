using AutoMapper;
using MyGamesAPI.Models.Domain;
using MyGamesAPI.Models.DTO;

namespace MyGamesAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Studio Mapping
            CreateMap<Studio,StudioDto>().ReverseMap();
            CreateMap<Studio,AddStudioRequestDto>().ReverseMap();
            CreateMap<Studio , UpdateStudioRequestDto>().ReverseMap();

            //Difficulty mapping
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();

            //Games mapping
            CreateMap<Game,GameDto>().ReverseMap();
            CreateMap<Game,AddGameRequestDto>().ReverseMap();
            CreateMap<Game, UpdateGameRequestDto>().ReverseMap();
        }
    }
}
