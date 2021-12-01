using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblTrainee
    {
        public int TraineeId { get; set; }
        public int? LeadId { get; set; }
        public int? BatchId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblBatch Batch { get; set; }
        public virtual TblLead Lead { get; set; }
    }
}
