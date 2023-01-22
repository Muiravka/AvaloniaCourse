using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coursach;

public partial class CourseContext : DbContext
{
    public CourseContext()
    {
    }

    public CourseContext(DbContextOptions<CourseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Droppedanime> Droppedanimes { get; set; }

    public virtual DbSet<Plantowatch> Plantowatches { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserComment> UserComments { get; set; }

    public virtual DbSet<Watchedanime> Watchedanimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=course;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Droppedanime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("droppedanime_pkey");

            entity.ToTable("droppedanime");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Animeid).HasColumnName("animeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Droppedanimes)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DroppedAnime_To_Users");
        });

        modelBuilder.Entity<Plantowatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("plantowatch_pkey");

            entity.ToTable("plantowatch");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Animeid).HasColumnName("animeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Plantowatches)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanToWatch_To_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.Nickname)
                .HasMaxLength(35)
                .HasColumnName("nickname");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(60)
                .HasColumnName("user_password");
        });

        modelBuilder.Entity<UserComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_comment_pkey");

            entity.ToTable("user_comment");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AnimeId).HasColumnName("anime_id");
            entity.Property(e => e.Commentcontent)
                .HasMaxLength(300)
                .HasColumnName("commentcontent");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.UserComments)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserComment_To_Users");
        });

        modelBuilder.Entity<Watchedanime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("watchedanime_pkey");

            entity.ToTable("watchedanime");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Animeid).HasColumnName("animeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Watchedanimes)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchedAnime_To_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
