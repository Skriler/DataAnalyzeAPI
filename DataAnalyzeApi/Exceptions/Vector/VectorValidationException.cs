﻿namespace DataAnalyzeApi.Exceptions.Vector;

public abstract class VectorValidationException : DataAnalyzeException
{
    public override int StatusCode { get; } = StatusCodes.Status400BadRequest;

    public override string ErrorTitle { get; } = "Vector validation error";

    public VectorValidationException(string message)
        : base(message)
    { }
}
