using BuildingBlocks.CQRS;
using UserManagement.Infrastructure.Data;
using UserService.Domain;

namespace UserService.Application.Commands.CreateUser;

public class CreateOrderHandler(UserDBContext dbContext)
    : ICommandHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {        
        var user = command.user;

        dbContext.USERS.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserResult(user.UserId);
    }    
}

