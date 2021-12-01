using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class BatchRepository : IBatchRepository
    {

        TrainingAcademyDBContext db;

        public BatchRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        #region GetBatches()
        public async Task<List<TblBatch>> GetBatches()
        {
            if (db != null)
            {
                return await db.TblBatch.ToListAsync();
            }
            return null;
        }
        #endregion

        #region AddBatch()
        public async Task<int> AddBatch(TblBatch Batch)
        {
            if (db != null)
            {
                await db.TblBatch.AddAsync(Batch);
                await db.SaveChangesAsync();
                return Batch.BatchId;
            }
            return 0;
        }
        #endregion

        #region DeleteBatch()
        public async Task<TblBatch> DeleteBatch(int id)
        {
            if (db != null)
            {
                TblBatch dbBatch = db.TblBatch.Find(id);
                db.TblBatch.Remove(dbBatch);
                db.SaveChanges();
                return dbBatch;
            }
            return null;
        }
        #endregion

        #region UpdateBatch()
        public async Task UpdateBatch(TblBatch Batch)
        {
            if (db != null)
            {
                db.TblBatch.Update(Batch);
                await db.SaveChangesAsync();
            }
        }
        #endregion

    }
}
