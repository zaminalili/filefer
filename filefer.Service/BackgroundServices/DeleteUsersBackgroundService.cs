using filefer.Data.Context;
using filefer.Service.Services;
using Microsoft.Extensions.Hosting;

namespace filefer.Service.BackgroundServices
{
    public class DeleteUsersBackgroundService: BackgroundService
    {
        private readonly IUserService userService;
        private readonly AppDbContext db;
        public DeleteUsersBackgroundService(IUserService userService, AppDbContext db)
        {
            this.userService = userService;
            this.db = db;
        }

        private void DeleteUserAccounts()
        {
            var usersToDelete = db.Users.Where(u => u.CreatedDate < DateTime.UtcNow.AddDays(-1)).ToList();
            foreach (var user in usersToDelete)
            {
                userService.DeleteAccountAsync(user);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                DeleteUserAccounts();
            }
        }
    }
}
