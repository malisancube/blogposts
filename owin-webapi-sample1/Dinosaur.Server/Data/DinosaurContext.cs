using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinosaur.Model;

namespace Dinosaur.Server.Data
{
    public class DinosaurContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DinosaurContext()
            : base("name=DinosaurContext")
        {
        }
    }
}
