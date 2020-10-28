using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Task2Web.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options ):base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Resident> Residents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .HasOne(p => p.House)
                .WithMany(t => t.Flats)
                .HasForeignKey(p => p.HouseId);

            modelBuilder.Entity<Resident>()
           .HasOne(p => p.Flat)
           .WithMany(t => t.Residents)
           .HasForeignKey(p => p.FlatId);

        }
    }
}
