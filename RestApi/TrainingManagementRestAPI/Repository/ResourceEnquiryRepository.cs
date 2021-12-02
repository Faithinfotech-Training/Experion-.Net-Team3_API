using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.ViewModel;

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


        #region getelementbyid(id)

        public async Task<List<TblResourceEnquiry>> GetResourceEnquiryById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join post and category





                return await (from e in db.TblResourceEnquiry
                              from d in db.TblResource
                              from l in db.TblLead
                              where e.ResourceEnquiryId == id && e.ResourceId == d.ResourceId && e.LeadId == l.LeadId
                              select new TblResourceEnquiry
                              {

                                  ResourceEnquiryId = e.ResourceEnquiryId,
                                  ResourceEnquiryStatus = e.ResourceEnquiryStatus,
                                  ResourceId = d.ResourceId,
                                  LeadId = l.LeadId,
                                  ResourceEnqiryDate = e.ResourceEnqiryDate,

                              }).ToListAsync();




            }
            return null;



        }


        #endregion

        #region Get All Resource Enquiry
        public async Task<List<ResourceEnquiryViewModel>> GetAllResourceEnquiry()
        {
            if (db != null)
            {
                return await(from e in db.TblResourceEnquiry
                             from l in db.TblLead
                             from r in db.TblResource
                             where e.LeadId == l.LeadId && e.ResourceId == r.ResourceId
                             select new ResourceEnquiryViewModel
                             {
                                ResourceEnquiryId = e.ResourceEnquiryId,
                                 ResourceId = e.ResourceId,
                                 LeadId = e.LeadId,
                                 ResourceEnquiryStatus = e.ResourceEnquiryStatus,
                                 ResourceEnqiryDate = e.ResourceEnqiryDate,
                                 ResourceName = r.ResourceName,
                                 LeadName = l.LeadName
                             }).ToListAsync();



            }
            return null;
        }
        #endregion
    }
}
