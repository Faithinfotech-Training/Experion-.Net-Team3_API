using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TrainingAcademyDBContext : DbContext
    {
        public TrainingAcademyDBContext()
        {
        }

        public TrainingAcademyDBContext(DbContextOptions<TrainingAcademyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBatch> TblBatch { get; set; }
        public virtual DbSet<TblBatchCourse> TblBatchCourse { get; set; }
        public virtual DbSet<TblCourse> TblCourse { get; set; }
        public virtual DbSet<TblCourseEnquiry> TblCourseEnquiry { get; set; }
        public virtual DbSet<TblLead> TblLead { get; set; }
        public virtual DbSet<TblResource> TblResource { get; set; }
        public virtual DbSet<TblResourceEnquiry> TblResourceEnquiry { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblSalesPipeline> TblSalesPipeline { get; set; }
        public virtual DbSet<TblTrainee> TblTrainee { get; set; }
        public virtual DbSet<TblTrainer> TblTrainer { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ANNMARYJOSE\\SQLEXPRESS;Initial Catalog=TrainingAcademyDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBatch>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PK__TblBatch__5D55CE58CA34A719");

                entity.Property(e => e.BatchName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBatchCourse>(entity =>
            {
                entity.HasKey(e => e.BatchCourseId)
                    .HasName("PK__TblBatch__3878FF916D911A4E");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.TblBatchCourse)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK__TblBatchC__Batch__571DF1D5");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblBatchCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TblBatchC__Cours__5812160E");
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__TblCours__C92D71A763D3F05C");

                entity.Property(e => e.CourseDescription).IsUnicode(false);

                entity.Property(e => e.CourseDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseFees).HasColumnType("money");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TblCourse)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__TblCourse__Train__403A8C7D");
            });

            modelBuilder.Entity<TblCourseEnquiry>(entity =>
            {
                entity.HasKey(e => e.CourseEnquiryId)
                    .HasName("PK__TblCours__9B00A0CE79BBCECF");

                entity.Property(e => e.CourseEnqiryDate).HasColumnType("date");

                entity.Property(e => e.CourseEnquiryStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnquiryDescription)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblCourseEnquiry)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TblCourse__Cours__60A75C0F");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblCourseEnquiry)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__TblCourse__LeadI__619B8048");
            });

            modelBuilder.Entity<TblLead>(entity =>
            {
                entity.HasKey(e => e.LeadId)
                    .HasName("PK__TblLead__73EF78FAD3A8E357");

                entity.Property(e => e.LeadId).ValueGeneratedNever();

                entity.Property(e => e.AddState)
                    .HasColumnName("Add_State")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HighestQualification)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LeadName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithOne(p => p.TblLead)
                    .HasForeignKey<TblLead>(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblLead__LeadId__5CD6CB2B");
            });

            modelBuilder.Entity<TblResource>(entity =>
            {
                entity.HasKey(e => e.ResourceId)
                    .HasName("PK__TblResou__4ED1816F276DD597");

                entity.Property(e => e.ResourceDescription).IsUnicode(false);

                entity.Property(e => e.ResourceFees).HasColumnType("money");

                entity.Property(e => e.ResourceName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblResourceEnquiry>(entity =>
            {
                entity.HasKey(e => e.ResourceEnquiryId)
                    .HasName("PK__TblResou__BA357E0F8D7C57A0");

                entity.Property(e => e.EnquiryDescription)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceEnqiryDate).HasColumnType("date");

                entity.Property(e => e.ResourceEnquiryStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblResourceEnquiry)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__TblResour__LeadI__656C112C");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TblResourceEnquiry)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK__TblResour__Resou__6477ECF3");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TblRole__8AFACE1A7B13F5EA");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalesPipeline>(entity =>
            {
                entity.HasKey(e => e.SalesPipelineId)
                    .HasName("PK__TblSales__EC8BF14EE827E108");

                entity.Property(e => e.CloseDate).HasColumnType("date");

                entity.Property(e => e.LastContact).HasColumnType("date");

                entity.Property(e => e.Priority)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Stage)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblSalesPipeline)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__TblSalesP__LeadI__68487DD7");
            });

            modelBuilder.Entity<TblTrainee>(entity =>
            {
                entity.HasKey(e => e.TraineeId)
                    .HasName("PK__TblTrain__3BA911CAA464ED3E");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.TblTrainee)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK__TblTraine__Batch__6E01572D");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblTrainee)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__TblTraine__LeadI__6D0D32F4");
            });

            modelBuilder.Entity<TblTrainer>(entity =>
            {
                entity.HasKey(e => e.TrainerId)
                    .HasName("PK__TblTrain__366A1A7CC624FA3E");

                entity.Property(e => e.TrainerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__TblUser__4DDA281817ED4141");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_LOGIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
