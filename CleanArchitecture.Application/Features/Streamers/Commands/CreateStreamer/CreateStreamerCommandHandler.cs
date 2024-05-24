using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastrucute;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"Couldn't insert streamer record");
            }

            _logger.LogInformation($"Streamer {streamerEntity.Id} was created successfully");

            await SendEmail(streamerEntity);

            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "jmartinez7214@gmail.com",
                Body = "The streamer company was created successfully",
                Subject = "Alert message"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email the {streamer.Id}");
            }
        }
    }
}
