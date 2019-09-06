using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SQWWebApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AreasController : ControllerBase
  {
    public AreasController()
    {

    }

    [HttpGet]
    public IActionResult getAll()
    {
      return Ok();
    }

    [HttpGet]
    public IActionResult getByAreaCode(string areaCode)
    {
      return Ok();
    }

    [HttpPost]
    public IActionResult insert()
    {
      return Ok();
    }

    [HttpPut]
    public IActionResult update()
    {
      return Ok();
    }

    [HttpDelete]
    public IActionResult delete()
    {
      return Ok();
    }
  }
}
