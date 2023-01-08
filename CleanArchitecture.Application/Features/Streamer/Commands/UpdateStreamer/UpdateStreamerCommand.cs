using MediatR;

namespace CleanArchitecture.Application.Features.Streamer2.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand: IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}
