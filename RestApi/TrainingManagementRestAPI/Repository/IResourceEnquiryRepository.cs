using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface IResourceEnquiryRepository
    {
        Task<List<TblResourceEnquiry>> GetResourceEnquiries();
        Task<int> AddResourceEnquiry(TblResourceEnquiry ResourceEnquiry);
        Task<TblResourceEnquiry> DeleteResourceEnquiry(int id);
        Task UpdateResourceEnquiry(TblResourceEnquiry ResourceEnquiry);
    }
}
