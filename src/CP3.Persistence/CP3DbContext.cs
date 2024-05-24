using CP3.Models;
using CP3.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CP3.Persistence
{
    public class Cp3DbContext(DbContextOptions<Cp3DbContext> options) : DbContext(options)
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new StudentClassMapping());
        }
    }
}
