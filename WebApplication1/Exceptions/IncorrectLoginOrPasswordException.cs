namespace WebApplication1.Exceptions;

public class IncorrectLoginOrPasswordException : Exception {
    public IncorrectLoginOrPasswordException() { }

    public IncorrectLoginOrPasswordException(string message) : base(message) { }

    public IncorrectLoginOrPasswordException(string message, Exception inner)
        : base(message, inner) { }
}