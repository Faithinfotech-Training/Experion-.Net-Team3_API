using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingManagementRestAPI.ViewModel
{
    public class TraineeViewModel
    {
        public int TraineeId { get; set; }
        public int? LeadId { get; set; }
        public int? BatchId { get; set; }
        public bool? IsActive { get; set; }
        public string LeadName { get; set; }
        public string BatchName { get; set; }
    }
}
