using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.Repository;

namespace TrainingManagementRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        ILeadRepository leadRepository;
        //constructor dependency injection
        public RegisterController(ILeadRepository _c)
        {
            leadRepository = _c;
        }

        #region Add user
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] TblUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = await leadRepository.AddUser(model);
                    if (UserId > 0)
                    {
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion
    }
}

