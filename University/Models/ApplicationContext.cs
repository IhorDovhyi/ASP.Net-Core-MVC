using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.HasIndex(e => e.Name, "UQ__COURSE__D9C1FA008AFBDE2A")
                    .IsUnique();

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUP");

                entity.HasIndex(e => e.Name, "UQ__GROUP__D9C1FA00E2AEBEA9")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_GROUPS_To_COURSES");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("LAST_NAME");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STUDENTS_To_GROUPS");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
