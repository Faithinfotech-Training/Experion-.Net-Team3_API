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

        ISalesPipelineRepository salespipelineRepository;
        //constructor dependency injection
        public SalesPipelineController(ISalesPipelineRepository _c)
        {
            salespipelineRepository = _c;
        }
        //Get all salespipeline
        #region Get SalesPipeline
        [HttpGet]
        public async Task<IActionResult> GetSalesPipelines()
        {

            try
            {
                var salespipelines = await salespipelineRepository.GetSalesPipelines();
                if (salespipelines == null)
                {
                    return NotFound();
                }
                return Ok(salespipelines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Add new salespipeline
        #region Add SalesPipeline
        [HttpPost]
        public async Task<IActionResult> AddSalesPipeline([FromBody] TblSalesPipeline model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var salespipelineId = await salespipelineRepository.AddSalesPipeline(model);
                    if (salespipelineId > 0)
                    {
                        return Ok(salespipelineId);
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

        //Update SalesPipeline
        #region Update SalesPipeline
        [HttpPut]
        public async Task<IActionResult> UpdateSalesPipeline([FromBody] TblSalesPipeline model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await salespipelineRepository.UpdateSalesPipeline(model);
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

        //Delete SalesPipeline
        #region Delete SalesPipeline

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesPipeline(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await salespipelineRepository.DeleteSalesPipeline(id);
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

        //Get SalesPipeline By Id
        #region GetSalesPipelineById

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesPipelineById(int id)

        {

            try

            {

                var salespipeline = await salespipelineRepository.GetSalesPipelineById(id);

                if (salespipeline == null)

                {

                    return NotFound();

                }

                return Ok(salespipeline);

            }

            catch (Exception)

            {

                return BadRequest();

            }
        }

        #endregion
    }
}
