using Microsoft.EntityFrameworkCore;

namespace UserApi.Models{
    public class UserContext:DbContext{
        public UserContext(DbContextOptions<UserContext> options)
        :base(options)
        {

        }
        public DbSet<User> Users{get;set;}
        public DbSet<Province> Provinces{get;set;}
    }
}