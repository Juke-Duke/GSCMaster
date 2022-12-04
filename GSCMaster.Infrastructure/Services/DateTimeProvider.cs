using GSCMaster.Application.Services;

namespace GSCMaster.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}