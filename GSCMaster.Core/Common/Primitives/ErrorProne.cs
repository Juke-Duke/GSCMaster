namespace GSCMaster.Core.Common.Primitives;
public sealed record ErrorProne<TValue>
    where TValue : notnull
{
    private readonly TValue _value = default!;

    private readonly HashSet<Error> _errors = new();

    public TValue Value => IsFaulty ? throw new InvalidOperationException("Value is faulty") : _value;

    public IReadOnlyList<Error> Errors => _errors.ToList();

    public bool IsFaulty => _errors.Any();

    private ErrorProne(TValue value)
        => _value = value;

    private ErrorProne(Error error)
        => _errors = new() { error };

    private ErrorProne(Error[] errors)
        => _errors = new(errors);

    private ErrorProne(List<Error> errors)
        => _errors = new(errors);

    public static implicit operator ErrorProne<TValue>(TValue value)
        => new(value);

    public static implicit operator ErrorProne<TValue>(Error error)
        => new(error);

    public static implicit operator ErrorProne<TValue>(Error[] errors)
        => new(errors);

    public static implicit operator ErrorProne<TValue>(List<Error> errors)
        => new(errors);

    public ErrorProne<TValue> Inspect(Predicate<TValue> inspection, Error error)
    {
        if (_value is null || !inspection(_value))
            _errors.Add(error);

        return this;
    }

    public async Task<ErrorProne<TValue>> InspectAsync(Func<TValue, Task<bool>> inspection, Error error)
    {
        if (_value is null || !await inspection(_value))
            _errors.Add(error);

        return this;
    }

    public void Dispatch(Action<TValue> onValue, Action<IReadOnlyList<Error>> onFaulty)
    {
        if (!IsFaulty)
            onValue(Value);
        else
            onFaulty(Errors);
    }

    public TResult Dispatch<TResult>(Func<TValue, TResult> onValue, Func<IReadOnlyList<Error>, TResult> onFaulty)
        => !IsFaulty
        ? onValue(Value)
        : onFaulty(Errors);

    public void DispatchFirst(Action<TValue> onValue, Action<Error> onFaulty)
    {
        if (!IsFaulty)
            onValue(Value);
        else
            onFaulty(Errors[0]);
    }

    public TResult DispatchFirst<TResult>(Func<TValue, TResult> onValue, Func<Error, TResult> onFaulty)
        => !IsFaulty
        ? onValue(Value)
        : onFaulty(Errors[0]);

    public async Task DispatchAsync(Func<TValue, Task> onValue, Func<IReadOnlyCollection<Error>, Task> onError)
    {
        if (!IsFaulty)
            await onValue(Value).ConfigureAwait(false);
        else
            await onError(Errors).ConfigureAwait(false);
    }

    public async Task<TResult> DispatchAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<IReadOnlyCollection<Error>, Task<TResult>> onError)
        => !IsFaulty
        ? await onValue(Value).ConfigureAwait(false)
        : await onError(Errors).ConfigureAwait(false);

    public async Task DispatchFirstAsync(Func<TValue, Task> onValue, Func<Error, Task> onError)
    {
        if (!IsFaulty)
            await onValue(Value).ConfigureAwait(false);
        else
            await onError(Errors[0]).ConfigureAwait(false);
    }

    public async Task<TResult> DispatchFirstAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<Error, Task<TResult>> onError)
        => !IsFaulty
        ? await onValue(Value).ConfigureAwait(false)
        : await onError(Errors[0]).ConfigureAwait(false);
}