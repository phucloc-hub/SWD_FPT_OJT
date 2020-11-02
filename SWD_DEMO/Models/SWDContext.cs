using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWD_DEMO.Models
{
    public partial class SWDContext : DbContext
    {
        public SWDContext()
        {
        }

        public SWDContext(DbContextOptions<SWDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<Falcuty> Falcuty { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MajorType> MajorType { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<SemesterStudent> SemesterStudent { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<UniFalcuty> UniFalcuty { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UniversityMajor> UniversityMajor { get; set; }
        public virtual DbSet<UniversitySemester> UniversitySemester { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:swdfpt.database.windows.net,1433;Initial Catalog=SWD;Persist Security Info=False;User ID=loccute;Password=S2xXZGVG3p6h;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcceptDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.StuCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Job1");

                entity.HasOne(d => d.StuCodeNavigation)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.StuCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Student");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Company_1");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNo).HasMaxLength(11);

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Account");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.HasKey(e => new { e.CompCode, e.UniCode });

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.UniCode).HasMaxLength(20);

                entity.Property(e => e.Duration).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.CompCodeNavigation)
                    .WithMany(p => p.Connection)
                    .HasForeignKey(d => d.CompCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connection_Company");

                entity.HasOne(d => d.UniCodeNavigation)
                    .WithMany(p => p.Connection)
                    .HasForeignKey(d => d.UniCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Connection_University");
            });

            modelBuilder.Entity<Falcuty>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Branch");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UniCode)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Benefit).HasMaxLength(100);

                entity.Property(e => e.CompCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.MajorCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subject)
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CompCodeNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CompCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Company");

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.MajorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Major");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.FalcutyCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FalcutyCodeNavigation)
                    .WithMany(p => p.Major)
                    .HasForeignKey(d => d.FalcutyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Major_Branch");
            });

            modelBuilder.Entity<MajorType>(entity =>
            {
                entity.HasKey(e => e.MajorCode);

                entity.Property(e => e.MajorCode).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithOne(p => p.MajorType)
                    .HasForeignKey<MajorType>(d => d.MajorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MajorType_Major1");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SemesterStudent>(entity =>
            {
                entity.HasKey(e => new { e.SemesterCode, e.StuCode });

                entity.Property(e => e.SemesterCode).HasMaxLength(20);

                entity.Property(e => e.StuCode).HasMaxLength(20);

                entity.HasOne(d => d.SemesterCodeNavigation)
                    .WithMany(p => p.SemesterStudent)
                    .HasForeignKey(d => d.SemesterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterStudent_Semester");

                entity.HasOne(d => d.StuCodeNavigation)
                    .WithMany(p => p.SemesterStudent)
                    .HasForeignKey(d => d.StuCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterStudent_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Student_1");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Cv)
                    .HasColumnName("CV")
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(60);

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.MajorCode).HasMaxLength(20);

                entity.Property(e => e.PhoneNo).HasMaxLength(10);

                entity.Property(e => e.UniCode).HasMaxLength(20);

                entity.Property(e => e.Graduation).HasMaxLength(20);



                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Account");

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.MajorCode)
                    .HasConstraintName("FK_Student_Major");

                entity.HasOne(d => d.UniCodeNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UniCode)
                    .HasConstraintName("FK_Student_University");
            });

            modelBuilder.Entity<UniFalcuty>(entity =>
            {
                entity.HasKey(e => new { e.FalcutyCode, e.UniCode })
                    .HasName("PK_UniBranch");

                entity.Property(e => e.FalcutyCode).HasMaxLength(20);

                entity.Property(e => e.UniCode).HasMaxLength(20);

                entity.HasOne(d => d.FalcutyCodeNavigation)
                    .WithMany(p => p.UniFalcuty)
                    .HasForeignKey(d => d.FalcutyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniBranch_Branch");

                entity.HasOne(d => d.UniCodeNavigation)
                    .WithMany(p => p.UniFalcuty)
                    .HasForeignKey(d => d.UniCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniBranch_University");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(11);

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_University_Account");
            });

            modelBuilder.Entity<UniversityMajor>(entity =>
            {
                entity.HasKey(e => new { e.UniCode, e.MajorCode });

                entity.Property(e => e.UniCode).HasMaxLength(20);

                entity.Property(e => e.MajorCode).HasMaxLength(20);

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.UniversityMajor)
                    .HasForeignKey(d => d.MajorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversityMajor_Major");

                entity.HasOne(d => d.UniCodeNavigation)
                    .WithMany(p => p.UniversityMajor)
                    .HasForeignKey(d => d.UniCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversityMajor_University");
            });

            modelBuilder.Entity<UniversitySemester>(entity =>
            {
                entity.HasKey(e => new { e.SemesterCode, e.UniCode });

                entity.Property(e => e.SemesterCode).HasMaxLength(20);

                entity.Property(e => e.UniCode).HasMaxLength(20);

                entity.HasOne(d => d.SemesterCodeNavigation)
                    .WithMany(p => p.UniversitySemester)
                    .HasForeignKey(d => d.SemesterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversitySemester_Semester");

                entity.HasOne(d => d.UniCodeNavigation)
                    .WithMany(p => p.UniversitySemester)
                    .HasForeignKey(d => d.UniCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversitySemester_University");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
