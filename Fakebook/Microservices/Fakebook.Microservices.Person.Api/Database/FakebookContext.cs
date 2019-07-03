using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Database
{
    public class FakebookContext:DbContext
    {
        public FakebookContext(DbContextOptions<FakebookContext> options)
          : base(options)
        {

        }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<PToken> PTokens { get; set; }
    }
}
