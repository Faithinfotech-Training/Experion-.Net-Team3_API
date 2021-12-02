using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingManagementRestAPI.ViewModel
{
    public class CourseEnquiryViewModel
    {
        public int CourseEnquiryId { get; set; }
        public int? CourseId { get; set; }
        public int? LeadId { get; set; }
        public string CourseEnquiryStatus { get; set; }
        public DateTime? CourseEnqiryDate { get; set; }
        public string CourseName { get; set; }
        public string LeadName { get; set; }


    }
}
