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
    public class PropertyController : ControllerBase
    {

        private readonly PropertyCore _propertyCore;
        private readonly IWebHostEnvironment _env;

        public PropertyController(IPropertyRepository propertyRepository, ILogger<Property> logger, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _env = enviroment;
            _propertyCore = new PropertyCore(propertyRepository, logger, mapper);
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Property>>> Get()
        {
            var response = await _propertyCore.GetAllAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetById(int id)
        {
            var response = await _propertyCore.GetByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<Property>>> GetByAll(FilterPropertiesDto filterProperties)
        {
            var response = await _propertyCore.GetByAllAsync(filterProperties);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPost]
        public async Task<ActionResult<Property>> Post([FromForm] PropertyCreateDto entity)
        {
            var response = await _propertyCore.AddAsync(entity, _env.ContentRootPath);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPut]
        public async Task<ActionResult<PropertyDto>> Put([FromForm] PropertyUpdateDto entity)
        {
            var response = await _propertyCore.UpdateAsync(entity);
            return StatusCode((int)response.StatusHttp, response);
        }

        [HttpPut("Price")]
        public async Task<ActionResult<Property>> PutPrice([FromBody] PropertyUpdatePriceDto entity)
        {
            var response = await _propertyCore.UpdatePriceAsync(entity);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
