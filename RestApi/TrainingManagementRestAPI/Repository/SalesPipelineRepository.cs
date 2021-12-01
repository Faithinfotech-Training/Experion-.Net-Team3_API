using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class SalesPipelineRepository : ISalesPipelineRepository
    {

        TrainingAcademyDBContext db;
        //constructor dependency injection
        public SalesPipelineRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        //get Cources
        #region Get SalesPipelines
        public async Task<List<TblSalesPipeline>> GetSalesPipelines()
        {
            if (db != null)
            {
                return await db.TblSalesPipeline.ToListAsync();
            }
            return null;
        }
        #endregion

        //Add Cource
        #region Add SalesPipeline
        public async Task<int> AddSalesPipeline(TblSalesPipeline salespipeline)
        {
            if (db != null)
            {
                await db.TblSalesPipeline.AddAsync(salespipeline);
                await db.SaveChangesAsync();
                return salespipeline.SalesPipelineId;

            }
            return 0;
        }
        #endregion

        //Update Cource
        #region Update SalesPipeline
        public async Task UpdateSalesPipeline(TblSalesPipeline salespipeline)
        {
            if (db != null)
            {
                db.TblSalesPipeline.Update(salespipeline);
                await db.SaveChangesAsync();//commit the transaction



            }
        }


        #endregion

        //Delete Cource
        #region Delete SalesPipeline
        public async Task DeleteSalesPipeline(int id)
        {


            TblSalesPipeline salespipeline = db.TblSalesPipeline.FirstOrDefault(cid => cid.SalesPipelineId == id);
            if (salespipeline != null)
            {
                db.TblSalesPipeline.Remove(salespipeline);
                await db.SaveChangesAsync();

            }
        }
        #endregion

        //get cource by id
        #region Get salespipeline by id
        public async Task<TblSalesPipeline> GetSalesPipelineById(int id)
        {
            if (db != null)
            {
                TblSalesPipeline salespipeline = await db.TblSalesPipeline.FindAsync(id);
                return salespipeline;

            }
            return null;
        }
        #endregion



    }
}
