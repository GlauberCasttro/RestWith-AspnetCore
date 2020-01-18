using Microsoft.EntityFrameworkCore;

namespace RestWebApiAspnetCore.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            
        }

        public MySqlContext( DbContextOptions<MySqlContext> options) : base(options) 
        {
        }
        public DbSet<Livro> Livro { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

       
    }
}
