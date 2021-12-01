using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {

        TrainingAcademyDBContext db;
        //constructor dependency injection
        public CourseRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        //get Cources
        #region Get Courses
        public async Task<List<TblCourse>> GetCourses()
        {
            if (db != null)
            {
                return await db.TblCourse.ToListAsync();
            }
            return null;
        }
        #endregion

        //Add Cource
        #region Add Course
        public async Task<int> AddCourse(TblCourse course)
        {
            if (db != null)
            {
                await db.TblCourse.AddAsync(course);
                await db.SaveChangesAsync();
                return course.CourseId;

            }
            return 0;
        }
        #endregion

        //Update Cource
        #region Update Course
        public async Task UpdateCourse(TblCourse course)
        {
            if (db != null)
            {
                db.TblCourse.Update(course);
                await db.SaveChangesAsync();//commit the transaction



            }
        }


        #endregion

        //Delete Cource
        #region Delete Course
        public async Task DeleteCourse(int id)
        {
           

            TblCourse course = db.TblCourse.FirstOrDefault(cid => cid.CourseId== id);
            if (course != null)
            {
                course.IsActive = false;
                await db.SaveChangesAsync();

            }
        }
        #endregion

        //get cource by id
        #region Get course by id
        public async Task<TblCourse> GetCourseById(int id)
        {
            if (db != null)
            {
                TblCourse course = await db.TblCourse.FindAsync(id);
                return course;

            }
            return null;
        }
        #endregion



    }
}
