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
    public class TraineeController : ControllerBase
    {
        ITraineeRepository traineeRepository;
        //constructor dependency injection
        public TraineeController (ITraineeRepository _c)
        {
            traineeRepository = _c;
        }
       
        #region Get trainee
        [HttpGet]
        public async Task<IActionResult> GetTrainee()
        {

            try
            {
                var trainees = await traineeRepository.GetTrainee();
                if (trainees == null)
                {
                    return NotFound();
                }
                return Ok(trainees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        
        #region Add Trainee
        [HttpPost]
        public async Task<IActionResult> AddTrainee([FromBody] TblTrainee model)
        {
            if (ModelState.IsValid)
            {
                
                
                    var traineeId = await traineeRepository.AddTrainee(model);
                    if (traineeId > 0)
                    {
                        return Ok(traineeId);
                    }
                    else
                    {
                        return NotFound();
                    }
               
            }
            return BadRequest();
        }
        #endregion

        
        #region Update trainee
        [HttpPut]
        public async Task<IActionResult> UpdateTrainee([FromBody] TblTrainee model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await traineeRepository.UpdateTrainee(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        
        #region Delete Trainee

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await traineeRepository.DeleteTrainee(id);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        #endregion

        
        #region GetTraineeById

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeById(int id)

        {

            try

            {

                var trainee = await traineeRepository.GetTraineeById(id);

                if (trainee == null)

                {

                    return NotFound();

                }

                return Ok(trainee);

            }

            catch (Exception)

            {

                return BadRequest();

            }
        }

        #endregion

 # region GetAllTrainee
        [HttpGet]
        [Route("GetAllTrainee")]
        public async Task<IActionResult> GetAllTrainee()
        {
            try
            {
                var details = await traineeRepository.GetAllTrainee();
                if (details == null)
                {
                    return NotFound();
                }
                return Ok(details);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

    }
}
