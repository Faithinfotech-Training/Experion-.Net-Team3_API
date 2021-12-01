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

        public SalesPipelineRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }

        #region GetSalesPipelines()
        public async Task<List<TblSalesPipeline>> GetSalesPipelines()
        {
            if (db != null)
            {
                return await db.TblSalesPipeline.ToListAsync();
            }
            return null;
        }
        #endregion

        #region AddSalesPipeline()
        public async Task<int> AddSalesPipeline(TblSalesPipeline SalesPipeline)
        {
            if (db != null)
            {
                await db.TblSalesPipeline.AddAsync(SalesPipeline);
                await db.SaveChangesAsync();
                return SalesPipeline.SalesPipelineId;
            }
            return 0;
        }
        #endregion

        #region DeleteSalesPipeline()
        public async Task<TblSalesPipeline> DeleteSalesPipeline(int id)
        {
            if (db != null)
            {
                TblSalesPipeline dbSalesPipeline = db.TblSalesPipeline.Find(id);
                db.TblSalesPipeline.Remove(dbSalesPipeline);
                db.SaveChanges();
                return dbSalesPipeline;
            }
            return null;
        }
        #endregion

        #region UpdateSalesPipeline()
        public async Task UpdateSalesPipeline(TblSalesPipeline SalesPipeline)
        {
            if (db != null)
            {
                db.TblSalesPipeline.Update(SalesPipeline);
                await db.SaveChangesAsync();
            }
        }
        #endregion

    }
}
