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

        public DbSet<Message> Message { get; set; }
        public DbSet<FriendTable> FriendTable { get; set; }
        public DbSet<People> People{ get; set; }
        public DbSet<PostTable> PostTable { get; set; }
        public DbSet<User_T> User_T { get; set; }
    }
}
