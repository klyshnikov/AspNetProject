using System;

namespace WebApplication1.Exceptions;

public class IncorrectPasswordException : Exception {
    public IncorrectPasswordException() { }

    public IncorrectPasswordException(string message) : base(message) { }

    public IncorrectPasswordException(string message, Exception inner)
        : base(message, inner) { }
}