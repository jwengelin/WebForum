using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebForum.Models.DB
{
    public partial class WebForumDBContext : DbContext
    {
        public WebForumDBContext()
        {
        }

        public WebForumDBContext(DbContextOptions<WebForumDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Threads> Threads { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("category_description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.DatePosted)
                    .HasColumnName("date_posted")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PostDescription)
                    .HasColumnName("post_description")
                    .HasMaxLength(4000);

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ThreadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__thread_id__4316F928");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__user_acco__440B1D61");
            });

            modelBuilder.Entity<Threads>(entity =>
            {
                entity.HasKey(e => e.ThreadId);

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ThreadDate)
                    .HasColumnName("thread_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ThreadTitle)
                    .HasColumnName("thread_title")
                    .HasMaxLength(200);

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Threads__categor__3F466844");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Threads__user_ac__403A8C7D");
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.HasKey(e => e.UserAccountId);

                entity.HasIndex(e => e.AccountName)
                    .HasName("UQ__UserAcco__6894C54A5E54A5A8")
                    .IsUnique();

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("account_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasColumnName("account_password")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAccou__role___3C69FB99");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Role)
                    .HasColumnName("_role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
