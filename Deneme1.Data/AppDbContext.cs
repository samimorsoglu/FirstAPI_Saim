using Deneme1.Core.Model;
using Deneme1.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.Entity<Employee>().HasKey(x => x.Id);  
            ///Bunları burda da tanımlayabilirdik ancak Best Practise açısından 
            ///DbContext sınıfı ne kadar sade kalırsa o kadar daha iyi olur.

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonelConfiguration());
        }
    }
}
