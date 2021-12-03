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

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-S5GL28D; Initial Catalog=TrainingAcademyDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBatch>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PK__TblBatch__5D55CE5882435615");

                entity.Property(e => e.BatchName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBatchCourse>(entity =>
            {
                entity.HasKey(e => e.BatchCourseId)
                    .HasName("PK__TblBatch__3878FF913CB3657D");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.TblBatchCourse)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK__TblBatchC__Batch__44FF419A");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblBatchCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TblBatchC__Cours__45F365D3");
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__TblCours__C92D71A7672281B7");

                entity.Property(e => e.CourseDescription).IsUnicode(false);

                entity.Property(e => e.CourseFees).HasColumnType("money");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TblCourse)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__TblCourse__Train__2E1BDC42");
            });

            modelBuilder.Entity<TblCourseEnquiry>(entity =>
            {
                entity.HasKey(e => e.CourseEnquiryId)
                    .HasName("PK__TblCours__9B00A0CE6D54D9FB");

                entity.Property(e => e.CourseEnqiryDate).HasColumnType("date");

                entity.Property(e => e.CourseEnquiryStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnquiryDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblCourseEnquiry)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TblCourse__Cours__38996AB5");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblCourseEnquiry)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("fk_lead_cenquiry");
            });

            modelBuilder.Entity<TblLead>(entity =>
            {
                entity.HasKey(e => e.LeadId)
                    .HasName("PK__TblLead__73EF78FA333EF373");

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
                    .HasConstraintName("FK__TblLead__LeadId__6477ECF3");
            });

            modelBuilder.Entity<TblResource>(entity =>
            {
                entity.HasKey(e => e.ResourceId)
                    .HasName("PK__TblResou__4ED1816F5B7C7A97");

                entity.Property(e => e.ResourceDescription).IsUnicode(false);

                entity.Property(e => e.ResourceFees).HasColumnType("money");

                entity.Property(e => e.ResourceName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblResourceEnquiry>(entity =>
            {
                entity.HasKey(e => e.ResourceEnquiryId)
                    .HasName("PK__TblResou__BA357E0F2C11E101");

                entity.Property(e => e.EnquiryDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceEnqiryDate).HasColumnType("date");

                entity.Property(e => e.ResourceEnquiryStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblResourceEnquiry)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("fk_lead_renquiry");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TblResourceEnquiry)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK__TblResour__Resou__3C69FB99");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TblRole__8AFACE1A9779BB65");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalesPipeline>(entity =>
            {
                entity.HasKey(e => e.SalesPipelineId)
                    .HasName("PK__TblSales__EC8BF14EE99ED5D1");

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
                    .HasConstraintName("fk_lead_sp");
            });

            modelBuilder.Entity<TblTrainee>(entity =>
            {
                entity.HasKey(e => e.TraineeId)
                    .HasName("PK__TblTrain__3BA911CA314FABCC");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.TblTrainee)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK__TblTraine__Batch__35BCFE0A");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblTrainee)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("fk_lead_trainee");
            });

            modelBuilder.Entity<TblTrainer>(entity =>
            {
                entity.HasKey(e => e.TrainerId)
                    .HasName("PK__TblTrain__366A1A7C8A38E555");

                entity.Property(e => e.TrainerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__TblUser__4DDA2818DAB9619D");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__TblUser__RoleId__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
