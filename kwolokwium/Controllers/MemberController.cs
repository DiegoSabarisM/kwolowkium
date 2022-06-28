using kwolokwium.Controllers.DTOs;
using kwolokwium.Services;
using Microsoft.AspNetCore.Mvc;


namespace kwolokwium.Controllers;


[ApiController]
[Route("api/[Controller]")]
public class MemberController : Controller
{
    private readonly IDbService _service;
    

    public MemberController(IDbService dbService)
        
    {
        _service = dbService;
    }
    
    [HttpPut]
    public async Task<IActionResult> AddMember([FromBody] someKindofMember member)
    {
        if (_service.addMember(member).Result) 
            
            return Ok(member);

        return NotFound("Did not make any changes");
    }


}