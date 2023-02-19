using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingCore.DAL;

using System.Data.Entity;
    

namespace CookingCore
{
    public class DbHelper
    {
        private SqlConnectionStringBuilder builder;
        private CookingContext _context;
        public DbHelper(CookingContext context)
        {
            _context = context;
        }

        private SqlConnectionStringBuilder initConnection()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "cooking-server.database.windows.net";
                builder.UserID = "cooking_admin";
                builder.Password = "Uptown!wizard12";
                builder.InitialCatalog = "CookingWizard";
                return builder;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        
        
       

        public void clearData()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nDropping Tables");
                    Console.WriteLine("=========================================\n");
                    String sql = "DROP TABLE dbo.Recipes;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void testConnection()
        {
            try
            {
                Console.WriteLine("Connection Successful");
                var users = _context.Users.Include(u => u.Recipes);
                foreach (var user in users)
                {
                    Console.WriteLine(user.FirstName);
                    foreach (var recipe in user.Recipes)
                    {
                        Console.WriteLine("-->"+recipe.Name);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
