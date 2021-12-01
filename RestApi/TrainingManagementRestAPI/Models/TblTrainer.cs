using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblTrainer
    {
        public TblTrainer()
        {
            TblCourse = new HashSet<TblCourse>();
        }

        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblCourse> TblCourse { get; set; }
    }
}
