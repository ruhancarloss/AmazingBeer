using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingBeer.Cerveja.Application;
using AmazingBeer.Cerveja.Application.AppModel.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazingBeer.Cerveja.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervejaController : ControllerBase
    {
        private readonly IApiAppService _apiAppService;

        public CervejaController(IApiAppService apiAppService)
        {
            _apiAppService = apiAppService;
        }

        // GET api/Cerveja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CervejaDTO>>> GetCervejas()
        {
            return Ok(_apiAppService.GetAllCervejas());
        }


        // GET api/Cerveja/5
        [HttpGet("{id}")]
        public ActionResult<CervejaDTO> Get(Guid id)
        {
            return _apiAppService.ReadCerveja(id);
        }

        // POST api/Cerveja
        [HttpPost]
        public async Task<ActionResult<CervejaDTO>> Post(CervejaDTO cerveja)
        {
            _apiAppService.AddCerveja(cerveja);
            return Ok(cerveja);
        }

        // PUT api/Cerveja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CervejaDTO cerveja)
        {
            if (id != cerveja.Id)
            {
                return BadRequest();
            }

            _apiAppService.UpdateCerveja(cerveja);
            return Ok(cerveja);

            //return NoContent();
        }

        // DELETE api/Cerveja/5
        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CervejaDTO>> Delete(Guid id)
        {
            _apiAppService.DeleteCerveja(_apiAppService.ReadCerveja(id));
            return Ok("Deletado");
        }
    }
}
