using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Properties.Contracts.Repository;
using Properties.Core.Core.V1;
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
    public class OwnerController : ControllerBase
    {

        private readonly OwnerCore _ownerCore;

        public OwnerController(IOwnerRepository ownerRepository, ILogger<Owner> logger)
        {
            _ownerCore = new OwnerCore(ownerRepository, logger);
        } 

        // GET: api/<OwnerController>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Owner>>> Get()
        {
            var response = await _ownerCore.GetAllAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(int id)
        {
            var response = await _ownerCore.GetByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<OwnerController>/5
        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<Owner>>> GetByName(string name)
        {
            var response = await _ownerCore.GetByName(name);
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public async Task<ActionResult<Owner>> Post([FromBody] Owner owner)
        {
            var response = await _ownerCore.AddAsync(owner);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<OwnerController>/5
        [HttpPut]
        public async Task<ActionResult<Owner>> Put([FromBody] Owner owner)
        {
            var response = await _ownerCore.UpdateAsync(owner);
            return StatusCode((int)response.StatusHttp, response);
        }

    }
}
