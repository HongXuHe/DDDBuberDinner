namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailError:IError
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}