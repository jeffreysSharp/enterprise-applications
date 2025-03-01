using Enterprise.Applications.Identity.Infra.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Enterprise.Applications.Identity.Infra.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
         }
        */


    }

}
