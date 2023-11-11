using System.Net;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.User;
using MediatR;
using OneOf;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler:IRequestHandler<RegisterCommand,OneOf<AuthenticationResult,IError>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository,IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<OneOf<AuthenticationResult, IError>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return new DuplicateEmailError(){StatusCode = (int)HttpStatusCode.Conflict,Message = "Email already exists"};
            //throw new Exception("User with given email already exists");
        }
        //create user generate unique id
        var user = new User()
        {
            FirstName = command.FirstName, 
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.Add(user);
        var userId = user.Id;
        var token = _jwtTokenGenerator.GenerateToken(userId, command.FirstName, command.LastName);
        //create jwtToken
        return new AuthenticationResult(user, token);
    }
}