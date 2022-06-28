using kwolokwium.Controllers.DTOs;

namespace kwolokwium.Services;

public interface IDbService
{
    
  Task<someKIndofTeam?> GetTeam(int idTeam);
   
  Task<bool> addMember(someKindofMember member);
}