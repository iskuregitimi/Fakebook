using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeBookENTITIY.DataBase

{
   public class DataContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=FakeBook; user id=sa; password=1234");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<FriendTable> FriendTables { get; set; }
        public DbSet<People> People{ get; set; }
        public DbSet<PostTable> PostTable { get; set; }

    }
}
