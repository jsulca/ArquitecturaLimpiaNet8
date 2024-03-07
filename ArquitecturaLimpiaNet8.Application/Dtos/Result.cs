namespace ArquitecturaLimpiaNet8.Application.Dtos;

public readonly struct Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    public Result(TValue value)
    {
        _value = value;
        _error = default;
    }

    public Result(TError error)
    {
        _error = error;
        _value = default;
    }

    public bool IsError { get; }

    public bool IsSuccess => !IsError;

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    public TResult Match<TResult>(Func<TValue, TResult> success, Func<TError, TResult> failure) =>
        IsError ? success(_value!) : failure(_error!);
}
