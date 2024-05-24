using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{Name} does not allow nulls");

            RuleFor(x => x.Url)
                .NotNull().WithMessage("{Url} does not allow nulls");
        }
    }
}
