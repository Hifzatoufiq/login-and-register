using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext>options):base(options) { }

      public  DbSet<register> table1 {  get; set; }
        public DbSet<product> table2 { get; set; }  
        public DbSet<WebApplication2.Models.login> login { get; set; } = default!;
    }
}
