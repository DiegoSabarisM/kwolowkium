using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kwolokwium.Models;
using kwolokwium.Services;

namespace kwolokwium.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class TeamController : Controller
{
   
    private readonly IDbService _service;
    

  public TeamController(IDbService dbService)
        
    {
        _service = dbService;
    }
  [HttpGet]
  [Route("{idTeam}")]
  public async Task<IActionResult> GetTeam(int idTeam)
  {
      try
      {
          return Ok(await _service.GetTeam(idTeam));
      }
      
      catch (System.Exception e)
      {
          Console.WriteLine(e);
          return Conflict();
      }
            
  }
 
}