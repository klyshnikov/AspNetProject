using System;

namespace WebApplication1.Exceptions;

public class IncorrectLoginException : Exception {
    public IncorrectLoginException() { }

    public IncorrectLoginException(string message) : base(message) { }

    public IncorrectLoginException(string message, Exception inner)
        : base(message, inner) { }
}