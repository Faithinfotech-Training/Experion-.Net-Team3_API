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
    public class SalesPipelineController : ControllerBase
    {
        ISalesPipelineRepository SalesPipelineRepository;
        public SalesPipelineController(ISalesPipelineRepository _p)
        {
            SalesPipelineRepository = _p;
        }

        #region GetSalesPipelines()
        [HttpGet]
        [Route("GetSalesPipelines")]
        public async Task<IActionResult> GetSalesPipelines()
        {
            try
            {
                var SalesPipelines = await SalesPipelineRepository.GetSalesPipelines();
                if (SalesPipelines == null)
                {
                    return NotFound();
                }
                return Ok(SalesPipelines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddSalesPipeline()
        [HttpPost]
        [Route("AddSalesPipeline")]
        public async Task<IActionResult> AddSalesPipeline([FromBody] TblSalesPipeline model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var SalesPipelineId = await SalesPipelineRepository.AddSalesPipeline(model);
                    if (SalesPipelineId > 0)
                    {
                        return Ok(SalesPipelineId);
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
        #region UpdateSalesPipeline();
        [HttpPut]
        [Route("UpdateSalesPipeline")]
        public async Task<IActionResult> UpdateSalesPipeline([FromBody] TblSalesPipeline model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await SalesPipelineRepository.UpdateSalesPipeline(model);
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
        #region DeleteSalesPipeline
        [HttpDelete]
        [Route("DeleteSalesPipeline")]
        public async Task<IActionResult> DeleteSalesPipeline(int id)
        {
            try
            {
                var enq = await SalesPipelineRepository.DeleteSalesPipeline(id);
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
