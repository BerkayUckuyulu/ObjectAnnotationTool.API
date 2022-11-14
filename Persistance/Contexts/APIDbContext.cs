using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Shape> Shapes { get; set; }
    }
}
