using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Properties.Contracts.Repository;
using Properties.Core.Core.V1;
using Properties.Entities.Dtos;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Properties.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly PropertyImageCore _propertyImageCore;

        public PropertyImageController(IPropertyImageRepository propertyRepository, ILogger<PropertyImage> logger, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _propertyImageCore = new PropertyImageCore(propertyRepository, logger, mapper, enviroment);
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<PropertyImageDto>>> Get()
        {
            var response = await _propertyImageCore.GetAllAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyImageDto>> GetById(int id)
        {
            var response = await _propertyImageCore.GetByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpGet("property/{id}")]
        public async Task<ActionResult<List<PropertyImageDto>>> GetByIdProperty(int id)
        {
            var response = await _propertyImageCore.GetByIdPropertyAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyImageDto>> Post([FromForm] PropertyImageCreateDto entity)
        {
            var response = await _propertyImageCore.AddAsync(entity);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPost("collection")]
        public async Task<ActionResult<PropertyImageDto>> PostCollection([FromForm] List<PropertyImageCreateDto> entity)
        {
            var response = await _propertyImageCore.AddCollectionAsync(entity);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPut]
        public async Task<ActionResult<PropertyImageDto>> Put([FromForm] PropertyImageUpdateDto entity)
        {
            var response = await _propertyImageCore.UpdateAsync(entity);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
