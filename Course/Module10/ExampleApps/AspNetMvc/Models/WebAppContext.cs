using AspNetMvc.Models;
using System.Data.Entity;

namespace AppMvc.Models
{
    public class WebAppContext : DbContext
    {
        public WebAppContext() : base("DefaultConnection")
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}