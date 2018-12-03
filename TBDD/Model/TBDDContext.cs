using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TBDD.Model
{
    public partial class TBDDContext : DbContext
    {
        public TBDDContext()
        {
        }

        public TBDDContext(DbContextOptions<TBDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceRollCall> AttendanceRollCall { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<ProfileStudent> ProfileStudent { get; set; }
        public virtual DbSet<ProfileTeacher> ProfileTeacher { get; set; }
        public virtual DbSet<RegisterSubject> RegisterSubject { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=TBDD;User Id=sa;Password=mssql-labs1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceRollCall>(entity =>
            {
                entity.ToTable("ATTENDANCE_ROLL_CALL");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckAttendance)
                    .HasColumnName("checkAttendance")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateCheck)
                    .HasColumnName("dateCheck")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterId)
                    .HasColumnName("registerID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(255);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(255);

                entity.Property(e => e.DateCreate)
                    .HasColumnName("dateCreate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacherID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProfileStudent>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("PROFILE_STUDENT");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfileTeacher>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("PROFILE_TEACHER");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specialize)
                    .HasColumnName("specialize")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterSubject>(entity =>
            {
                entity.HasKey(e => e.RegisterId);

                entity.ToTable("REGISTER_SUBJECT");

                entity.Property(e => e.RegisterId)
                    .HasColumnName("registerID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateStart)
                    .HasColumnName("dateStart")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacherID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FaceId)
                    .HasColumnName("faceID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId)
                    .HasColumnName("personID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECT");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SubjectName)
                    .HasColumnName("subjectName")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHER");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacherID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
