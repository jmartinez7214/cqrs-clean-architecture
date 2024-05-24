using MediatR;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommand : IRequest<int>
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public int VideoId { get; set; }
    }
}
