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
        //constructor dependency injection
        public BatchRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        //get Batches
        #region Get Batches
        public async Task<List<TblBatch>> GetBatches()
        {
            if (db != null)
            {
                return await db.TblBatch.ToListAsync();
            }
            return null;
        }
        #endregion

        //Add Batch
        #region Add Batch
        public async Task<int> AddBatch(TblBatch batch)
        {
            if (db != null)
            {
                await db.TblBatch.AddAsync(batch);
                await db.SaveChangesAsync();
                return batch.BatchId;

            }
            return 0;
        }
        #endregion

        //Update Batch
        #region Update Batch
        public async Task UpdateBatch(TblBatch batch)
        {
            if (db != null)
            {
                db.TblBatch.Update(batch);
                await db.SaveChangesAsync();//commit the transaction



            }
        }


        #endregion

        //Delete Batch
        #region Delete Batch
        public async Task DeleteBatch(int id)
        {


            TblBatch batch = db.TblBatch.FirstOrDefault(cid => cid.BatchId == id);
            if (batch != null)
            {
                batch.IsActive = false;
                await db.SaveChangesAsync();

            }
        }
        #endregion

        //get batch by id
        #region Get batch by id
        public async Task<TblBatch> GetBatchById(int id)
        {
            if (db != null)
            {
                TblBatch batch = await db.TblBatch.FindAsync(id);
                return batch;

            }
            return null;
        }
        #endregion



    }
}
