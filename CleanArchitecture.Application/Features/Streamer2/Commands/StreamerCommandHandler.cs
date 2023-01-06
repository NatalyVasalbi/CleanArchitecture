using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Streamer.Commands;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamer2.Commands
{
    // "parametros", "lo que quiero que devuelva"
    public class StreamerCommandHandler : IRequestHandler<StreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<StreamerCommandHandler> _logger;

        public StreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<StreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(StreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Domain.Streamer>(request); // convierte la data request(StreamerCommand) al tipo Streamer
            var newStreamer =  await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado exitosamemente");

            await SendEmail(newStreamer);
            return newStreamer.Id;
        }
        private async Task SendEmail(Domain.Streamer streamer)
        {
            var email = new Email
            {
                To = "nvalbitres@gmail.com",
                Body = "La compañia Streamer se creo correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {streamer.id}");
            }
        }
    }
}
