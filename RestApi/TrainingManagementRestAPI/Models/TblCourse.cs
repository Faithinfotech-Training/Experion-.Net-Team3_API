using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblBatchCourse = new HashSet<TblBatchCourse>();
            TblCourseEnquiry = new HashSet<TblCourseEnquiry>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal? CourseFees { get; set; }
        public int? TrainerId { get; set; }
        public bool? IsActive { get; set; }
        public string CourseDescription { get; set; }

        public virtual TblTrainer Trainer { get; set; }
        public virtual ICollection<TblBatchCourse> TblBatchCourse { get; set; }
        public virtual ICollection<TblCourseEnquiry> TblCourseEnquiry { get; set; }
    }
}
