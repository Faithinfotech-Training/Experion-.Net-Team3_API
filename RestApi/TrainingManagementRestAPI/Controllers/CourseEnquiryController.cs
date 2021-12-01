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
    public class CourseEnquiryController : ControllerBase
    {
        ICourseEnquiryRepository CourseEnquiryRepository;
        public CourseEnquiryController(ICourseEnquiryRepository _p)
        {
            CourseEnquiryRepository = _p;
        }

        #region GetCourseEnquiries()
        [HttpGet]
        [Route("GetCourseEnquiries")]
        public async Task<IActionResult> GetResourceEnquiries()
        {
            try
            {
                var CourseEnquiries = await CourseEnquiryRepository.GetCourseEnquiries();
                if (CourseEnquiries == null)
                {
                    return NotFound();
                }
                return Ok(CourseEnquiries);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddCourseEnquiry()
        [HttpPost]
        [Route("AddCourseEnquiry")]
        public async Task<IActionResult> AddCourseEnquiry([FromBody] TblCourseEnquiry model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var CourseEnquiryId = await CourseEnquiryRepository.AddCourseEnquiry(model);
                    if (CourseEnquiryId > 0)
                    {
                        return Ok(CourseEnquiryId);
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
        #region UpdateCourseEnquiry();
        [HttpPut]
        [Route("UpdateCourseEnquiry")]
        public async Task<IActionResult> UpdateCourseEnquiry([FromBody] TblCourseEnquiry model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await CourseEnquiryRepository.UpdateCourseEnquiry(model);
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
        #region DeleteCourseEnquiry
        [HttpDelete]
        [Route("DeleteCourseEnquiry")]
        public async Task<IActionResult> DeleteCourseEnquiry(int id)
        {
            try
            {
                var enq = await CourseEnquiryRepository.DeleteCourseEnquiry(id);
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
