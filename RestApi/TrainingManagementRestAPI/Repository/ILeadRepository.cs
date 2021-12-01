using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;namespace TrainingManagementRestAPI.Repository
{
    public interface ILeadRepository
    {
        //--- get lead ---//
        Task<List<TblLead>> GetLead();
        //--- get lead by id ---//
        Task<TblLead> GetLeadById(int id);
        //--- add lead ---//
        Task<int> AddLead(TblLead lead); 
        //--- update lead ---//
        Task UpdateLead(TblLead lead);
        //--- delete lead ---//
        Task DeleteLead(int id); 
        //add userlogin//
       Task<int> AddUser(TblUser user);
    }
}


