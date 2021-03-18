using Microsoft.EntityFrameworkCore;
using WIS.Models;

namespace WIS.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}