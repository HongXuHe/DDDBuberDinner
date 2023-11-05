using System.Net;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthenticationController:ControllerBase
{
    private readonly ISender _mediator;


    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result =
            await _mediator.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email,
                request.Password));

        return  result.Match(authResult => Ok(MapAuthResult(authResult)),
            error => Problem(statusCode: error.StatusCode, title: error.Message));
      
    }

    [HttpPost("login")]             
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _mediator.Send(new LoginQuery(request.Email,request.Password));
        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
        return Ok(response);
    }

    [NonAction]
    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return  new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
    }
}