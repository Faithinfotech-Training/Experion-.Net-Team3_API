using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        TrainingAcademyDBContext db;
        //constructor dependency injection
        public ResourceRepository(TrainingAcademyDBContext _db)
        {
            db = _db;
        }
        //Get Resources

        #region Get Resources
        public async Task<List<TblResource>> GetResources()
        {
            if (db != null)
            {
                return await db.TblResource.ToListAsync();
            }
            return null;
        }
        #endregion

        //Add Resource
        #region Add Resource
        public async Task<int> AddResource(TblResource resource)
        {
            if (db != null)
            {
                await db.TblResource.AddAsync(resource);
                await db.SaveChangesAsync();
                return resource.ResourceId;

            }
            return 0;
        }
        #endregion

        //Update Resource
        #region Update resource
        public async Task UpdateResource(TblResource resource)
        {
            if (db != null)
            {
                db.TblResource.Update(resource);
                await db.SaveChangesAsync();



            }
        }
        #endregion

        //Delete Resource
        #region Delete resource
        public async Task DeleteResource(int id)
        {
            TblResource resource = db.TblResource.FirstOrDefault(rid => rid.ResourceId == id);
            if (resource != null)
            {
                resource.IsActive = false;
                await db.SaveChangesAsync();

            }
        }


        #endregion

        //Get Resource By Id
        #region Get Resource by id
        public async Task<TblResource> GetResourceById(int id)
        {
            if (db != null)
            {
                TblResource resource = await db.TblResource.FindAsync(id);
                return resource;

            }
            return null;
        }

       

        #endregion





    }
}
