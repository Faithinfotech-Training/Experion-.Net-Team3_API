using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingManagementRestAPI.ViewModel
{
    public class ResourceEnquiryViewModel
    {
        public int ResourceEnquiryId { get; set; }
        public int? ResourceId { get; set; }
        public int? LeadId { get; set; }
        public string ResourceEnquiryStatus { get; set; }
        public DateTime? ResourceEnqiryDate { get; set; }
        public string LeadName { get; set; }
        public string ResourceName { get; set; }
    }
}
