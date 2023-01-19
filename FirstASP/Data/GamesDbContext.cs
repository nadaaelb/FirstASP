using Microsoft.EntityFrameworkCore;
using FirstASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FirstASP.MyIdentity;

namespace FirstASP.Data
{
    public class GamesDbContext : IdentityDbContext<SiteUser>
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> opt) : base(opt)
        {

        }
        //public DbSet<Games> Games { get; set; }
        public DbSet<Games> vgames => Set<Games>();
        public DbSet<User> users => Set<User>();    
        //public DbSet<User> Content { get; set; }   
    }
}
