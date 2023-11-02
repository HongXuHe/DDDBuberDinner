using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication;

public class AuthenticationService:IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }
        //create user generate unique id
        var user = new User(){FirstName = firstName, LastName = lastName,Email = email,Password = password};
        _userRepository.Add(user);
        var userId = user.Id;
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        //create jwtToken
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("user not exists");
        }

        if (user.Password != password) throw new Exception("Invalid password");
        var token = _jwtTokenGenerator.GenerateToken(userId: user.Id, user.FirstName, user.LastName);
        return new AuthenticationResult(user, token);
    }
}