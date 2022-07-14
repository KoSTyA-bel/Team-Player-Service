using FluentValidation;
using TeamService.BusinessLogic.Entities;

namespace TeamService.Grpc.ValidationSettings;

public class TeamValidator : AbstractValidator<Team>
{
    public TeamValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(2, 100);
    }
}
