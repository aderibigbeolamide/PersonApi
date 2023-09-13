using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Entity;
using Microsoft.EntityFrameworkCore;
using PersonApi.Entity;

namespace PersonApi.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        public DbSet<Person> Persons {get; set;}
    }
}
