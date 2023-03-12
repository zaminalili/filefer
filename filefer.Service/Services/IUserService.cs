using filefer.Entity.Entites;

namespace filefer.Service.Services
{
    public interface IUserService
    {
        Task DeleteAccountAsync(AppUser user);
    }
}
