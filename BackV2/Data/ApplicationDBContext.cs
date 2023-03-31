using Back.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq;
using System.Data;

namespace Back.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>context): base(context) {
        }
        public DbSet<Race> Race { get; set; }

        public DbSet<Size> Size { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Size>()
               .HasData(Enum.GetValues(typeof(SizeEnum))
                   .Cast<SizeEnum>()
                   .Select(e => new Size
                   {
                       Id = (int)e,
                       Name = e.ToString()
                   }));

            modelBuilder
                .Entity<Race>()          
                .HasOne(r => r.Size);
        }
    }
}
    