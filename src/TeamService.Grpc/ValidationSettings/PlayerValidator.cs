using FluentValidation;
using TeamService.BusinessLogic.Entities;

namespace TeamService.Grpc.ValidationSettings;

public class PlayerValidator : AbstractValidator<Player>
{
    public PlayerValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(2, 100);
    }
}
