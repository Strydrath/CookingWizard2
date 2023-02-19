using CookingCore;
using CookingCore.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookingCLI
{
    class Program
    {
        static void Main(string[] args) 
        {

            CookingContext context = new CookingContext();
            DbHelper db = new DbHelper(context);
            db.testConnection();
        }
    }
}