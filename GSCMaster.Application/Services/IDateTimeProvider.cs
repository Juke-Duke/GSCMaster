namespace GSCMaster.Application.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}