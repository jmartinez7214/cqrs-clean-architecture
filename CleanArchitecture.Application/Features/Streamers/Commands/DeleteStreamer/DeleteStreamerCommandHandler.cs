using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mappper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mappper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mappper = mappper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                _logger.LogError($"{request.Id} streamer not found");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            //await _streamerRepository.DeleteAsync(streamerToDelete);
            _unitOfWork.StreamerRepository.DeleteEntity(streamerToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"{request.Id} streamer was deleted successfully");

            return Unit.Value;
        }
    }
}
