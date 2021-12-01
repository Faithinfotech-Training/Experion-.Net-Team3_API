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
    public class ResourceController : ControllerBase
    {


        IResourceRepository resourceRepository;
        //constructor dependency injection
        public ResourceController(IResourceRepository _r)
        {
            resourceRepository = _r;
        }
        //Get all resource
        #region Get Resource
        [HttpGet]
        public async Task<IActionResult> GetResources()
        {

            try
            {
                var resources = await resourceRepository.GetResources();
                if (resources == null)
                {
                    return NotFound();
                }
                return Ok(resources);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Add new Resource
        #region Add Resource
        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] TblResource model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resourceId = await resourceRepository.AddResource(model);
                    if (resourceId > 0)
                    {
                        return Ok(resourceId);
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

        //Update Resource
        #region Update Resource
        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromBody] TblResource model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await resourceRepository.UpdateResource(model);
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

        //Delete Resource
        #region Delete Resource

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await resourceRepository.DeleteResource(id);
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

        //Get Resource By Id
        #region GetResourceById

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(int id)

        {

            try

            {

                var resource = await resourceRepository.GetResourceById(id);

                if (resource== null)

                {

                    return NotFound();

                }

                return Ok(resource);

            }

            catch (Exception)

            {

                return BadRequest();

            }
        }

        #endregion
    }
}

