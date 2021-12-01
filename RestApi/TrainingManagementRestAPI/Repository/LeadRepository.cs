using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
namespace TrainingManagementRestAPI.Repository
{
    public class LeadRepository : ILeadRepository
    {



        TrainingAcademyDBContext db;



        public LeadRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }



        #region Getlead()
        public async Task<List<TblLead>> GetLead()
        {
            if (db != null)
            {
                return await db.TblLead.ToListAsync();
            }
            return null;
        }
        #endregion



        #region AddLead()
        public async Task<int> AddLead(TblLead lead)
        {
            if (db != null)
            {
                await db.TblLead.AddAsync(lead);
                await db.SaveChangesAsync();
                return lead.LeadId;
            }
            return 0;
        }
        #endregion



        #region Delete lead
        public async Task DeleteLead(int id)
        {





            TblLead lead = db.TblLead.FirstOrDefault(lid => lid.LeadId == id);
            if (lead != null)
            {
                lead.IsActive = false;
                await db.SaveChangesAsync();





            }
        }
        #endregion



        #region UpdateLead()
        public async Task UpdateLead(TblLead lead)
        {
            if (db != null)
            {
                db.TblLead.Update(lead);
                await db.SaveChangesAsync();
            }
        }
        #endregion



        #region Get Lead by id
        public async Task<TblLead> GetLeadById(int id)
        {
            if (db != null)
            {
                TblLead lead = await db.TblLead.FindAsync(id);
                return lead;



            }
            return null;
        }
        #endregion



        #region AddUser()




        public async Task<int> AddUser(TblUser user)
        {
            if (db != null)
            {



                await db.TblUser.AddAsync(user);
                await db.SaveChangesAsync();
                return user.LoginId;
            }
            return 0;
        }




        #endregion



    }
}

