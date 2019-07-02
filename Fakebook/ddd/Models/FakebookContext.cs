using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ddd.Models
{
    public partial class FakebookContext : DbContext
    {
        public FakebookContext()
        {
        }

        public FakebookContext(DbContextOptions<FakebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SKLKMJ1\\SQLEXPRESS;Database=Fakebook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.Property(e => e.FriendsId).HasColumnName("FriendsID");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Person1Id).HasColumnName("Person1ID");

                entity.Property(e => e.Person2Id).HasColumnName("Person2ID");

                entity.HasOne(d => d.Person1)
                    .WithMany(p => p.FriendsPerson1)
                    .HasForeignKey(d => d.Person1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friends_Persons");

                entity.HasOne(d => d.Person2)
                    .WithMany(p => p.FriendsPerson2)
                    .HasForeignKey(d => d.Person2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friends_Persons1");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionName).HasMaxLength(50);

                entity.Property(e => e.ControllerName).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.IncommingId).HasColumnName("IncommingID");

                entity.Property(e => e.MessageBody)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MessageDate).HasColumnType("date");

                entity.Property(e => e.OutgoingId).HasColumnName("OutgoingID");

                entity.HasOne(d => d.Incomming)
                    .WithMany(p => p.MessagesIncomming)
                    .HasForeignKey(d => d.IncommingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Persons1");

                entity.HasOne(d => d.Outgoing)
                    .WithMany(p => p.MessagesOutgoing)
                    .HasForeignKey(d => d.OutgoingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Persons");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PostDate).HasColumnType("date");

                entity.Property(e => e.PostImage).IsRequired();

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Persons");
            });
        }
    }
}
