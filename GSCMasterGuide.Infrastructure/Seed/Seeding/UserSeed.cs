using GSCMasterGuide.Core.Entities;
using GSCMasterGuide.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;

namespace GSCMasterGuide.Infrastructure.Seed.Seeding;
public static class UserSeed
{
    public static async Task Seed(UserManager<Trainer> userManager)
    {
        if (userManager.Users.Any())
            return;

        await userManager.CreateAsync(new Trainer { UserName = "test", Email = "test@mail.com", Password = "remove this" }, "pass123");
    }
}