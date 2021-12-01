using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
   public  interface IResourceRepository
    {
        //Get all Resource
        Task<List<TblResource>> GetResources();

        //Add a new Resource
        Task<int> AddResource(TblResource resource);

        //Update Resource
        Task UpdateResource(TblResource resource);

        //Delete Resource
        Task DeleteResource(int id);

        //Get Resource by id
        Task<TblResource> GetResourceById(int id);






    }
}
