using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using castleknights1.Models;
using castleknights1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace castleknights1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CastleController : ControllerBase
    {
        private readonly CastleService _service;
        private readonly KnightService _ks;
        public CastleController(CastleService service, KnightService ks)
        {
            _service = service;
            _ks = ks;
        }
        [HttpGet]
        public ActionResult<Castle> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Castle> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Castle> Create([FromBody] Castle newProd)
        {
            try
            {
                return Ok(_service.Create(newProd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Castle> Edit([FromBody] Castle updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Castle> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/knight")]
        public ActionResult<IEnumerable<Knight>> GetKnights(int id)
        {
            try
            {
                return Ok(_ks.GetByCastleId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

