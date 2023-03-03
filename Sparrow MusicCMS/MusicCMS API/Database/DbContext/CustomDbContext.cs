using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicCMS_API.Database.IdentityAuth;

namespace MusicCMS_API.Database.DbContext
{
    public class CustomDbContext : IdentityDbContext<CustomUser>
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
