using Microsoft.EntityFrameworkCore;
using PracticaCosmosDb.Model;


namespace PracticaCosmosDb.Data
{
    public class AppDbContexts : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public AppDbContexts(DbContextOptions<AppDbContexts> options): base(options) {
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("cliente");
        }


    }
}
