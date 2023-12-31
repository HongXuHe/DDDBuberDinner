﻿
using BuberDinner.Application.Common.Errors;
using MediatR;
using OneOf;

namespace BuberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password):IRequest<OneOf<AuthenticationResult,IError>>;
