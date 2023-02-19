using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingCore.Models;

namespace CookingCore.DAL
{
    public class CookingContext : DbContext
    {
        private static string config = "XXX";
        public CookingContext() :base(config)
        {
            Configuration.ProxyCreationEnabled = true;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Console.WriteLine("OnModelCreating");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<User>()
                .HasMany<Recipe>(g => g.Recipes)
                .WithRequired(s => s.Author);

        }
    }
}
