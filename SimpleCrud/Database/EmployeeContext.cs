using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleCrud.Models;

namespace SimpleCrud.Database
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.EmployeeID)
               .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeNumber)
                .IsFixedLength(true)
                .IsRequired(true);

                entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsRequired(true);

                entity.Property(e => e.DateOfBirth)
                .IsRequired(true);

                entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsRequired(true);

                entity.Property(e => e.IDNumber)
                  .HasMaxLength(10)
                  .IsRequired(true)
                 .IsFixedLength(true);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        EmployeeID=1,
                        EmployeeNumber = 10000,
                        FullName = "Ajith Ramawickrama",
                        DateOfBirth = new DateTime(1988, 10, 22),
                        IDNumber = "234242312X",
                        Address = "Colombo Sri Lanka"
                    },
                     new Employee
                     {
                         EmployeeID = 2,
                         EmployeeNumber = 10000,
                         FullName = "Perter Manuel",
                         DateOfBirth = new DateTime(1988, 10, 31),
                         IDNumber = "234242312X",
                         Address = "New york, United States"
                     }
                );
        }
    }
}
