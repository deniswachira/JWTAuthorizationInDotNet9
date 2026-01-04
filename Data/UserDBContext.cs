using JWTAuthorizationInDotNet9.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthorizationInDotNet9.Data
{
    public class UserDBContext(DbContextOptions<UserDBContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
