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
    public class BatchController : ControllerBase
    {

        IBatchRepository batchRepository;
        //constructor dependency injection
        public BatchController(IBatchRepository _c)
        {
            batchRepository = _c;
        }
        //Get all batch
        #region Get Batch
        [HttpGet]
        public async Task<IActionResult> GetBatches()
        {

            try
            {
                var batches = await batchRepository.GetBatches();
                if (batches == null)
                {
                    return NotFound();
                }
                return Ok(batches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Add new batch
        #region Add Batch
        [HttpPost]
        public async Task<IActionResult> AddBatch([FromBody] TblBatch model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var batchId = await batchRepository.AddBatch(model);
                    if (batchId > 0)
                    {
                        return Ok(batchId);
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

        //Update Batch
        #region Update Batch
        [HttpPut]
        public async Task<IActionResult> UpdateBatch([FromBody] TblBatch model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await batchRepository.UpdateBatch(model);
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

        //Delete Batch
        #region Delete Batch

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await batchRepository.DeleteBatch(id);
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

        //Get Batch By Id
        #region GetBatchById

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatchById(int id)

        {

            try

            {

                var batch = await batchRepository.GetBatchById(id);

                if (batch == null)

                {

                    return NotFound();

                }

                return Ok(batch);

            }

            catch (Exception)

            {

                return BadRequest();

            }
        }

        #endregion
    }
}
