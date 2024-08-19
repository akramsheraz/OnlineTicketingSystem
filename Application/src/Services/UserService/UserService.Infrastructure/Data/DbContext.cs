using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Domain;


namespace UserManagement.Infrastructure.Data
{
    public class UserDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public UserDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> USERS { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
    }


}
