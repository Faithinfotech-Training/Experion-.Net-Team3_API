using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
   public interface ICourseRepository
    {
        //Get all Course
        Task<List<TblCourse>> GetCourses();

        //Add a new course
        Task<int> AddCourse(TblCourse course);

        //Update course
        Task UpdateCourse(TblCourse course);

        //Delete Course
        Task DeleteCourse(int id);

        //Get course by id
        Task<TblCourse> GetCourseById(int id);






    }
}
