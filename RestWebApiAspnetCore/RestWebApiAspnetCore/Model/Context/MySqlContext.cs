using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestWebApiAspnetCore.Model
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            
        }

        public MySqlContext( DbContextOptions<MySqlContext> options) : base(options) 
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
