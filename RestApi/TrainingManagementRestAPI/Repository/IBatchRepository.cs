using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface IBatchRepository
    {
        Task<List<TblBatch>> GetBatches();
        Task<int> AddBatch(TblBatch Batch);
        Task<TblBatch> DeleteBatch(int id);
        Task UpdateBatch(TblBatch Batch);
    }
}
