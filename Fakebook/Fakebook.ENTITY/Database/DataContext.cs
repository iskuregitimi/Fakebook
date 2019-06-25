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
            optionsBuilder.UseSqlServer(@"Server=BK-LAB204-IS020;Database=FakeBook; user id=sa; password=123");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<People> People{ get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
