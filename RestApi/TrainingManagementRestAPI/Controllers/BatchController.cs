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
        IBatchRepository BatchRepository;
        public BatchController(IBatchRepository _p)
        {
            BatchRepository = _p;
        }

        #region GetBatches()
        [HttpGet]
        [Route("GetBatches")]
        public async Task<IActionResult> GetBatches()
        {
            try
            {
                var Batches = await BatchRepository.GetBatches();
                if (Batches == null)
                {
                    return NotFound();
                }
                return Ok(Batches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddBatch()
        [HttpPost]
        [Route("AddBatch")]
        public async Task<IActionResult> AddBatch([FromBody] TblBatch model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var BatchId = await BatchRepository.AddBatch(model);
                    if (BatchId > 0)
                    {
                        return Ok(BatchId);
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
        #region UpdateBatch();
        [HttpPut]
        [Route("UpdateBatch")]
        public async Task<IActionResult> UpdateBatch([FromBody] TblBatch model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await BatchRepository.UpdateBatch(model);
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
        #region DeleteBatch
        [HttpDelete]
        [Route("DeleteBatch")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            try
            {
                var enq = await BatchRepository.DeleteBatch(id);
                if (enq == null)
                {
                    return NotFound();
                }
                return Ok(enq);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
