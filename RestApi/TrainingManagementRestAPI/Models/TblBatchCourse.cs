using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblBatchCourse
    {
        public int BatchCourseId { get; set; }
        public int? BatchId { get; set; }
        public int? CourseId { get; set; }

        public virtual TblBatch Batch { get; set; }
        public virtual TblCourse Course { get; set; }
    }
}
