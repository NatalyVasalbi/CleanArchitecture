using MediatR;

namespace CleanArchitecture.Application.Features.Streamer2.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand: IRequest
    {
        public int Id { get; set; }
    }
}
