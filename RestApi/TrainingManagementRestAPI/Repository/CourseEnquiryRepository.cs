using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class CourseEnquiryRepository:ICourseEnquiryRepository
    {

        TrainingAcademyDBContext db;

        public CourseEnquiryRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        #region GetCourseEnquiries()
        public async Task<List<TblCourseEnquiry>>GetCourseEnquiries()
        {
            if(db!=null)
            {
                return await db.TblCourseEnquiry.ToListAsync();
            }
            return null;
        }
        #endregion

        #region AddCourseEnquiry()
        public async Task<int> AddCourseEnquiry(TblCourseEnquiry CourseEnquiry)
        {
            if (db != null)
            {
                await db.TblCourseEnquiry.AddAsync(CourseEnquiry);
                await db.SaveChangesAsync();
                return CourseEnquiry.CourseEnquiryId;
            }
            return 0;
        }
        #endregion

        #region DeleteCourseEnquiry()
        public async Task<TblCourseEnquiry> DeleteCourseEnquiry(int id)
        {
            if(db!=null)
            {
                TblCourseEnquiry dbCourseEnquiry = db.TblCourseEnquiry.Find(id);
                db.TblCourseEnquiry.Remove(dbCourseEnquiry);
                db.SaveChanges();
                return dbCourseEnquiry;
            }
            return null;
        }
        #endregion

        #region UpdateCourseEnquiry()
        public async Task UpdateCourseEnquiry(TblCourseEnquiry CourseEnquiry)
        {
            if(db!=null)
            {
                db.TblCourseEnquiry.Update(CourseEnquiry);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region getelementbyid(id)

        public async Task<List<TblCourseEnquiry>> GetCourseEnquiryById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join post and category





                return await (from e in db.TblCourseEnquiry
                              from d in db.TblCourse
                              from l in db.TblLead
                              where e.CourseEnquiryId == id && e.CourseId == d.CourseId && e.LeadId == l.LeadId
                              select new TblCourseEnquiry
                              {

                                  CourseEnquiryId = e.CourseEnquiryId,
                                  CourseEnquiryStatus = e.CourseEnquiryStatus,
                                  CourseId = d.CourseId,
                                  LeadId = l.LeadId,
                                  CourseEnqiryDate = e.CourseEnqiryDate,

                              }).ToListAsync();




            }
            return null;



        }
        #endregion

    }
}
