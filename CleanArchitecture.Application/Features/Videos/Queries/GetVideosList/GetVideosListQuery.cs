using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    // Para hacer la comunicacion entre Query y QueryHandler mediante MediaTr se necesita llamar a la libreria IRequest
    // Va a devolver videos VideosVm (ViewModel)
    public class GetVideosListQuery: IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetVideosListQuery(string username)
        {
            _Username=username?? throw new ArgumentNullException(nameof(username));
        }
    }
}
