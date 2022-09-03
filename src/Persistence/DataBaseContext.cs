using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
                        
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>( e => {
               e.HasKey(e => e.id);
               e
                .HasMany( e => e.contracts)
                .WithOne()
                .HasForeignKey( c => c.idPerson);
            });
            builder.Entity<Contract>( e => {
                e.HasKey(e => e.id);
            });
        }

    }
}