namespace GSCMaster.Core.Common.Primitives;
public readonly record struct Error
{
    public readonly string Code { get; init; }

    public readonly string Message { get; init; }

    public Error()
        : this("None", "No Error.") { }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString()
        => $"{Code}: {Message}";
}