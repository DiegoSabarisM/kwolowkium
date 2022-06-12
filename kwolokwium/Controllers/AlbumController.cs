using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kwolokwium.Models;
using kwolokwium.Services;

namespace kwolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : Controller
{
    private readonly IDbService _service;
    

  public AlbumController(IDbService dbService)
        
    {
        _service = dbService;
    }
  [HttpGet]
  [Route("{idAlbum}")]
  public async Task<IActionResult> GetZamowienia(int idAlbum)
  {
      try
      {
          return Ok(await _service.GetAlbum(idAlbum));
      }
      
      catch (System.Exception)
      {
          return Conflict();
      }
            
  }
  
  [HttpDelete]
  [Route("{idMusician}")]
  public async Task<IActionResult> DeleteMusician(int idMusician)
  {
      try
      {
          return Ok( _service.DeleteMusician(idMusician));
      }
      
      catch (System.Exception)
      {
          return Conflict();
      }
            
  }
   
}