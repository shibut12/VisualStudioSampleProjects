using System;
using System.Data.Entity;

namespace CodeFirstApp01
{
    public class personContext : DbContext
    {
        public personContext() { }

        public DbSet<Person> Persons { get; set; }
    }
}
