using FluentResults;

namespace Fetagne.Application.Common.Errors;

public class PasswordsDoNotMatchError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
