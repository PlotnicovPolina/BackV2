using Back.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BackV2.Data.Entities;

namespace Back.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>context): base(context) {
        }
        public DbSet<Race> Race { get; set; }

        public DbSet<Size> Size { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Block> Blocks { get; set; }


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
    