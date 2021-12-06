using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.ViewModel;

namespace TrainingManagementRestAPI.Repository
{
    public class TraineeRepository:ITraineeRepository
    {
        TrainingAcademyDBContext db;

        public TraineeRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        #region GetTrainee()
        public async Task<List<TblTrainee>> GetTrainee()
        {
            if (db != null)
            {
                return await db.TblTrainee.ToListAsync();
            }
            return null;
        }
        #endregion

        #region AddTrainee()
        public async Task<int> AddTrainee(TblTrainee trainee)
        {
            if (db != null)
            {
                await db.TblTrainee.AddAsync(trainee);
                await db.SaveChangesAsync();
                return trainee.TraineeId;
            }
            return 0;
        }
        #endregion

        #region DeleteTrainee()
        
        public async Task DeleteTrainee(int id)
        {


            TblTrainee trainee = db.TblTrainee.FirstOrDefault(tid => tid.TraineeId == id);
            if (trainee != null)
            {
                trainee.IsActive = false;
                await db.SaveChangesAsync();

            }
        }
        #endregion
        #region UpdateTrainee()
        public async Task UpdateTrainee(TblTrainee trainee)
        {
            if (db != null)
            {
                db.TblTrainee.Update(trainee);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region gettraineebyid(id)

       
        public async Task<TblTrainee> GetTraineeById(int id)
        {
            if (db != null)
            {
                TblTrainee trainee = await db.TblTrainee.FindAsync(id);
                return trainee;

            }
            return null;
        }
        #endregion

        #region Get all Trainee details
        public async Task<List<TraineeViewModel>> GetAllTrainee()
        {
            if (db != null)
            {
                return await (from t in db.TblTrainee
                              from l in db.TblLead
                              from b in db.TblBatch
                              where t.LeadId == l.LeadId && t.BatchId == b.BatchId
                              select new TraineeViewModel
                              {
                                  TraineeId = t.TraineeId,
                                   LeadId = t.LeadId,
        BatchId =t.BatchId,
        IsActive =t.IsActive,
         LeadName =l.LeadName,
         BatchName=b.BatchName
    }).ToListAsync();

            }
            return null;
        }


        #endregion

    }
}