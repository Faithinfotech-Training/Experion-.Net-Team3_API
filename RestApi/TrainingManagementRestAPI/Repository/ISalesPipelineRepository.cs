using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface ISalesPipelineRepository
    {
        //Get all SalesPipeline
        Task<List<TblSalesPipeline>> GetSalesPipelines();

        //Add a new salespipeline
        Task<int> AddSalesPipeline(TblSalesPipeline salespipeline);

        //Update salespipeline
        Task UpdateSalesPipeline(TblSalesPipeline salespipeline);

        //Delete SalesPipeline
        Task DeleteSalesPipeline(int id);

        //Get salespipeline by id
        Task<TblSalesPipeline> GetSalesPipelineById(int id);






    }
}
