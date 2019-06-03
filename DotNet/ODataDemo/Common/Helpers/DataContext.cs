using Microsoft.EntityFrameworkCore;
using ODataDemo.Common.Models;

namespace ODataDemo.Common.Helpers
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
