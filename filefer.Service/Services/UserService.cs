using filefer.Entity.Entites;
using Microsoft.AspNetCore.Identity;

namespace filefer.Service.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<AppUser> userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task DeleteAccountAsync(AppUser user)
        {
            user.UploadedFiles.Clear();
            await userManager.DeleteAsync(user);
        }
    }
}
