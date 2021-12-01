using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface ISalesPipelineRepository
    {
        Task<List<TblSalesPipeline>> GetSalesPipelines();
        Task<int> AddSalesPipeline(TblSalesPipeline SalesPipeline);
        Task<TblSalesPipeline> DeleteSalesPipeline(int id);
        Task UpdateSalesPipeline(TblSalesPipeline SalesPipeline);
    }
}
