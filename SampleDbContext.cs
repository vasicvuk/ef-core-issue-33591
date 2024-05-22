using EFCoreIssue33591.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreIssue33591
{
    public class SampleDbContext  : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransportBase>().ToTable("base");
            modelBuilder.Entity<TransportBase>().Property(x => x.Id).ValueGeneratedNever();
            modelBuilder.Entity<Car>().ToTable("car");
            modelBuilder.Entity<Car>().OwnsOne(x => x.Motor, y =>
            {
                y.Property(z => z.Power);
                y.Property(z => z.FuelType);
                y.Property(z => z.Ccm);
            });
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=temp1.db").UseCamelCaseNamingConvention();
    }
}
