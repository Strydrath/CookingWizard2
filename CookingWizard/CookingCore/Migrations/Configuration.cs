using CookingCore.Models;

namespace CookingCore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CookingCore.DAL.CookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CookingCore.DAL.CookingContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    ID = 1, FirstName = "Carson", LastName = "Alexander", JoinTime = DateTime.Parse("2005-09-01")
                },
                new User
                {
                    ID = 2, FirstName = "Meredith", LastName = "Alonso", JoinTime = DateTime.Parse("2002-09-01"), Recipes = new List<Recipe>()
                },
                new User { ID = 3, FirstName = "Arturo", LastName = "Anand", JoinTime = DateTime.Parse("2003-09-01"), Recipes = new List<Recipe>()},
                new User
                {
                    ID = 4, FirstName = "Gytis", LastName = "Barzdukas", JoinTime = DateTime.Parse("2002-09-01"), Recipes = new List<Recipe>()
                },
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    CookTime = 20, Description = "This is a test recipe", Name = "Spaghetti", Author = users[0]
                },
                new Recipe
                {
                    CookTime = 20, Description = "This is a test recipe", Name = "Chicken", Author = users[1]
                },
                new Recipe { CookTime = 20, Description = "This is a test recipe", Name = "Beef", Author = users[2] }
            };
            recipes.ForEach(s => context.Recipes.Add(s));
            context.SaveChanges();
            users[0].Recipes.Add(recipes[0]);
            users[1].Recipes.Add(recipes[1]);
            users[2].Recipes.Add(recipes[2]);

        }
    }
}
