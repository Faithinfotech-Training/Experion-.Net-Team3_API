using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblBatch
    {
        public TblBatch()
        {
            TblBatchCourse = new HashSet<TblBatchCourse>();
            TblTrainee = new HashSet<TblTrainee>();
        }

        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public int? BatchStrength { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblBatchCourse> TblBatchCourse { get; set; }
        public virtual ICollection<TblTrainee> TblTrainee { get; set; }
    }
}
