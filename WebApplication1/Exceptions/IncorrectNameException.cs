namespace WebApplication1.Exceptions;

public class IncorrectNameException : Exception {
    public IncorrectNameException() { }

    public IncorrectNameException(string message) : base(message) { }

    public IncorrectNameException(string message, Exception inner)
        : base(message, inner) { }
}