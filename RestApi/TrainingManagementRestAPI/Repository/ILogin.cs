using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public interface ILogin
    {
        public TblUser GetUser(TblUser tblUser);

        Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd);
        public TblUser validateUser(string username, string password);
    }
}
