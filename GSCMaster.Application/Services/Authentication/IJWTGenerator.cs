using GSCMaster.Core.TrainerAggregate;

namespace GSCMaster.Application.Services.Authentication;
public interface IJWTGenerator
{
    string GenerateToken(Trainer trainer);
}