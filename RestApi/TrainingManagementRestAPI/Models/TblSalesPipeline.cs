using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblSalesPipeline
    {
        public int SalesPipelineId { get; set; }
        public int? LeadId { get; set; }
        public string Stage { get; set; }
        public string Priority { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? LastContact { get; set; }

        public virtual TblLead Lead { get; set; }
    }
}
