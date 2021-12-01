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
    public class ResourceEnquiryController : ControllerBase
    {
        IResourceEnquiryRepository ResourceEnquiryRepository;
        public ResourceEnquiryController(IResourceEnquiryRepository _p)
        {
            ResourceEnquiryRepository = _p;
        }

        #region GetResourceEnquiries()
        [HttpGet]
        [Route("GetResourceEnquiries")]
        public async Task<IActionResult> GetResourceEnquiries()
        {
            try
            {
                var ResourceEnquiries = await ResourceEnquiryRepository.GetResourceEnquiries();
                if (ResourceEnquiries == null)
                {
                    return NotFound();
                }
                return Ok(ResourceEnquiries);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddResourceEnquiry()
        [HttpPost]
        [Route("AddResourceEnquiry")]
        public async Task<IActionResult> AddResourceEnquiry([FromBody] TblResourceEnquiry model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ResourceEnquiryId = await ResourceEnquiryRepository.AddResourceEnquiry(model);
                    if (ResourceEnquiryId > 0)
                    {
                        return Ok(ResourceEnquiryId);
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
        #region UpdateResourceEnquiry();
        [HttpPut]
        [Route("UpdateResourceEnquiry")]
        public async Task<IActionResult> UpdateResourceEnquiry([FromBody] TblResourceEnquiry model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ResourceEnquiryRepository.UpdateResourceEnquiry(model);
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
        #region DeleteResourceEnquiry
        [HttpDelete]
        [Route("DeleteResourceEnquiry")]
        public async Task<IActionResult> DeleteResourceEnquiry(int id)
        {
            try
            {
                var enq = await ResourceEnquiryRepository.DeleteResourceEnquiry(id);
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
