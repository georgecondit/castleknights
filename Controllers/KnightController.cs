using System;
using System.Collections.Generic;
using castleknights1.Models;
using castleknights1.Services;
using Microsoft.AspNetCore.Mvc;

namespace castleknights1.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KnightController : ControllerBase
  {

    private readonly KnightService _service;

    public KnightController(KnightService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Knight>> Get()
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
    public ActionResult<Knight> Get(int id)
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
    public ActionResult<Knight> Create([FromBody] Knight newEarl)
    {
      try
      {
        return Ok(_service.Create(newEarl));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Knight> Edit([FromBody] Knight updated, int id)
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
    public ActionResult<Knight> Delete(int id)
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

  }
}