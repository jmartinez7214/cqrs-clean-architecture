using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} cannot exceed 50 characters");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} is required");
        }
    }
}
