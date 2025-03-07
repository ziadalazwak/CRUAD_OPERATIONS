using Microsoft.EntityFrameworkCore;

namespace L_1_dependcy_injection.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>().ToTable("products");
        }

    }
}
