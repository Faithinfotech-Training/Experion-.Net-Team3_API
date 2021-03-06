using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;

namespace TrainingManagementRestAPI.Repository
{
    public class Login : ILogin
    {
        TrainingAcademyDBContext _db;
        //Dependency injection
        public Login(TrainingAcademyDBContext db)
        {
            _db = db;
        }
        public TblUser GetUser(TblUser login)
        {
            if (_db != null)
            {
                TblUser dbuser = _db.TblUser.FirstOrDefault(em => em.UserName == login.UserName && em.UserPassword == login.UserPassword);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }

            return null;
        }

        public async Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd)
        {
            if (_db != null)
            {
                TblUser tblUser = await _db.TblUser.FirstOrDefaultAsync(em => em.UserName == un && em.UserPassword == pwd);
                return tblUser;
            }
            return null;

        }

        public TblUser validateUser(string username, string password)
        {
            if (_db != null)
            {
                TblUser dbuser = _db.TblUser.FirstOrDefault(em => em.UserName == username && em.UserPassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }

    }
}