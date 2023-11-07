namespace BuberDinner.Application.Common.Errors;

public class GenericCommandValidateError:IError
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}