using AutoMapper;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // origen, destino
            CreateMap<Video, VideosVm>();
        }
    }
}
