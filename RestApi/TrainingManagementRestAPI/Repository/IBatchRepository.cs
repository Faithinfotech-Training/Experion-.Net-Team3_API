using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface IBatchRepository
    {
        //Get all Batch
        Task<List<TblBatch>> GetBatches();

        //Add a new batch
        Task<int> AddBatch(TblBatch batch);

        //Update batch
        Task UpdateBatch(TblBatch batch);

        //Delete Batch
        Task DeleteBatch(int id);

        //Get batch by id
        Task<TblBatch> GetBatchById(int id);
    }
}
