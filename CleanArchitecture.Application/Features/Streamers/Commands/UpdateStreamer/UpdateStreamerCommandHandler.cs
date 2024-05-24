using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mappper;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mappper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mappper = mappper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);
            var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"Streamer with id {request.Id} not found");
                throw new NotFoundException(nameof(Streamers), request.Id);
            }

            _mappper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

            //await _streamerRepository.UpdateAsync(streamerToUpdate);

            _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Streamer updated successfully {request.Id}");

            return Unit.Value;
        }
    }
}
