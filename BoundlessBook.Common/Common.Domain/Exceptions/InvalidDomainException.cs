﻿namespace BoundlessBook.Common.Common.Domain.Exceptions;

public class InvalidDomainException : Exception
{
    public InvalidDomainException()
    {

    }

    public InvalidDomainException(string message) : base(message)
    {

    }
}