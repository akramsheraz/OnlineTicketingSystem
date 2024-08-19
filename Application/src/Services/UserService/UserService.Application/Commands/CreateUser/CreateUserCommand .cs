using FluentValidation;
using UserService.Domain;
using BuildingBlocks.CQRS;

namespace UserService.Application.Commands.CreateUser;
public record CreateUserCommand(User user)   : ICommand<CreateUserResult>;

public record CreateUserResult(int Id);

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.user.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.user.FirstName).NotNull().WithMessage("FirstName is required");
        RuleFor(x => x.user.LastName).NotEmpty().WithMessage("LastName should not be empty");
        RuleFor(x => x.user.UserType).NotEmpty().WithMessage("UserType should not be empty");
    }
}