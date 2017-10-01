using Microsoft.EntityFrameworkCore;
 
namespace EntityCRUD.Models
{
    public class GOTcontext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public GOTcontext(DbContextOptions<GOTcontext> options) : base(options) { }
        public DbSet<House> houses {get; set;}
        public DbSet<Character> characters {get; set;}
    }
}
