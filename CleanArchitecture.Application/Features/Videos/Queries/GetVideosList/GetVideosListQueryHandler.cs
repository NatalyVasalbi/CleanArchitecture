using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    // En IRequestHandler le indicamos como parametro ("el origen que envia el mensaje", "el reusltado deseado")
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {        
        private readonly IVideoRepository _videoRepository; // Inyectamos el interface
        private readonly IMapper _mapper; //Mapear entidad Videos y VideoVm

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            // incorporo la logica para hacer la consulta a la BD
            var videosList = await _videoRepository.GetVideoByUsername(request._Username);

            return _mapper.Map<List<VideosVm>>(videosList); //el destino sea VideosVm tranformando el videosList
        }
    }
}
