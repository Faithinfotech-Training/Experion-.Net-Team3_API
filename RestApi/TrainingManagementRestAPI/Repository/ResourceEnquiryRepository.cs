using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class ResourceEnquiryRepository:IResourceEnquiryRepository
    {

        TrainingAcademyDBContext db;

        public ResourceEnquiryRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        #region GetResourceEnquiries()
        public async Task<List<TblResourceEnquiry>> GetResourceEnquiries()
        {
            if (db != null)
            {
                return await db.TblResourceEnquiry.ToListAsync();
            }
            return null;
        }
        #endregion

        #region AddResourceEnquiry()
        public async Task<int> AddResourceEnquiry(TblResourceEnquiry ResourceEnquiry)
        {
            if (db != null)
            {
                await db.TblResourceEnquiry.AddAsync(ResourceEnquiry);
                await db.SaveChangesAsync();
                return ResourceEnquiry.ResourceEnquiryId;
            }
            return 0;
        }
        #endregion

        #region DeleteResourceEnquiry()
        public async Task<TblResourceEnquiry> DeleteResourceEnquiry(int id)
        {
            if (db != null)
            {
                TblResourceEnquiry dbResourceEnquiry = db.TblResourceEnquiry.Find(id);
                db.TblResourceEnquiry.Remove(dbResourceEnquiry);
                await db.SaveChangesAsync();
                return dbResourceEnquiry;
            }
            return null;
        }
        #endregion

        #region UpdateResourceEnquiry()
        public async Task UpdateResourceEnquiry(TblResourceEnquiry ResourceEnquiry)
        {
            if (db != null)
            {
                db.TblResourceEnquiry.Update(ResourceEnquiry);
                await db.SaveChangesAsync();
            }
        }
        #endregion
    }
}
