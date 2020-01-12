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
        public virtual DbSet<UserPosts> UserPosts { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserThreads> UserThreads { get; set; }
     
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

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ThreadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__thread_id__3C69FB99");
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

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Threads__categor__398D8EEE");
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.HasKey(e => e.UserAccountId);

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.Property(e => e.AccountName)
                    .HasColumnName("account_name")
                    .HasMaxLength(100);

                entity.Property(e => e.AccountPassword)
                    .HasColumnName("account_password")
                    .HasMaxLength(400);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserAccou__role___412EB0B6");
            });

            modelBuilder.Entity<UserPosts>(entity =>
            {
                entity.HasKey(e => e.UpId);

                entity.Property(e => e.UpId).HasColumnName("up_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__UserPosts__post___44FF419A");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__UserPosts__user___440B1D61");
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

            modelBuilder.Entity<UserThreads>(entity =>
            {
                entity.HasKey(e => e.UtId);

                entity.Property(e => e.UtId).HasColumnName("ut_id");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.UserThreads)
                    .HasForeignKey(d => d.ThreadId)
                    .HasConstraintName("FK__UserThrea__threa__48CFD27E");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.UserThreads)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__UserThrea__user___47DBAE45");
            });
        }
    }
}
