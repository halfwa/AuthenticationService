using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Models.Db.Contexts
{
    public sealed class AuthAppContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public AuthAppContext(DbContextOptions<AuthAppContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
