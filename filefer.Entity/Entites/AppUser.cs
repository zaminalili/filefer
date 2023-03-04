using Microsoft.AspNetCore.Identity;

namespace filefer.Entity.Entites
{
    public class AppUser: IdentityUser<Guid>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }
    }
}
