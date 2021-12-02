using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.ViewModel;

namespace TrainingManagementRestAPI.Repository
{
    public interface ICourseEnquiryRepository
    {
        Task<List<TblCourseEnquiry>> GetCourseEnquiries();
        Task<int> AddCourseEnquiry(TblCourseEnquiry CourseEnquiry);
        Task<TblCourseEnquiry> DeleteCourseEnquiry(int id);
        Task UpdateCourseEnquiry(TblCourseEnquiry CourseEnquiry);
        Task<List<CourseEnquiryViewModel>> GetAllCourseEnquiry();
    }
}
