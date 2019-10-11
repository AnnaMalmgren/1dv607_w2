using System;

public class PinFormatException : Exception
{
    public PinFormatException()
    {
    }

    public PinFormatException(string message)
        : base(message)
    {
    }

    public PinFormatException(string message, Exception inner)
        : base(message, inner)
    {
    }
}