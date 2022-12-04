using GSCMaster.Core.Entities;

namespace GSCMaster.Application.Services.Authentication;
public interface IJWTGenerator
{
    string GenerateToken(Trainer trainer);
}