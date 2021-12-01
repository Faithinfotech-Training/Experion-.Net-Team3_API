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
    public class CourseController : ControllerBase
    {

        ICourseRepository courseRepository;
        //constructor dependency injection
        public CourseController(ICourseRepository _c)
        {
            courseRepository = _c;
        }
        //Get all course
        #region Get Course
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {

            try
            {
                var courses = await courseRepository.GetCourses();
                if (courses == null)
                {
                    return NotFound();
                }
                return Ok(courses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Add new course
        #region Add Course
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] TblCourse model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var courseId = await courseRepository.AddCourse(model);
                    if (courseId > 0)
                    {
                        return Ok(courseId);
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

        //Update Course
        #region Update Course
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] TblCourse model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await courseRepository.UpdateCourse(model);
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

        //Delete Course
        #region Delete Course

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await courseRepository.DeleteCourse(id);
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

        //Get Course By Id
        #region GetCourseById
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)

        {

            try

            {

                var course = await courseRepository.GetCourseById(id);

                if (course == null)

                {

                    return NotFound();

                }

                return Ok(course);

            }

            catch (Exception)

            {

                return BadRequest();

            }
        }

        #endregion
    }
}
