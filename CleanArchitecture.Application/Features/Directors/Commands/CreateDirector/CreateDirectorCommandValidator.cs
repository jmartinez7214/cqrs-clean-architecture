using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(p => p.Firstname)
                .NotNull().WithMessage("{Firstname can't be null}");

            RuleFor(p => p.Lastname)
                .NotNull().WithMessage("{Lastname can't be null}");
        }
    }
}
