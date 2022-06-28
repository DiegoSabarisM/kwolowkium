
using kwolokwium.Controllers.DTOs;
using kwolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace kwolokwium.Services;

public class DbService : IDbService
{
    private readonly MainDbContext _context;
    private IDbService _dbServiceImplementation;

    public DbService(MainDbContext context)
    {
        _context = context;
    }


    public async Task<someKIndofTeam?> GetTeam(int idTeam)
    {
        return await _context.Teams.Where(t => t.TeamID == idTeam).Select(t => new someKIndofTeam()
        {
            TeamID = t.TeamID,
            TeamName = t.TeamName,
            TeamDescription = t.TeamDescription,
            Organization = _context.Organizations.Where(o => o.OrganizationID == t.OrganizaionID)
                .Select(o => new someKindofOrganization()
                {
                    OrganizationName = o.OrganizationName,
                    OrganizationID = o.OrganizationID,
                    Members = _context.Members.Select(m => new someKindofMember()
                    {
                        MemberID = m.MemberID,
                        MemberName = m.MemberName
                    }).ToList()


                }).FirstOrDefault(),
            Memberships = _context.Memberships.Select(m => new someKindofMembership()
            {
                MembershipDate = m.MembershipDate
            }).OrderBy(m => m.MembershipDate).ToList()
        }).FirstOrDefaultAsync();
        
    }

    public async Task<bool> addMember(someKindofMember member)
    {

        {
            var _member = new Member()
            {
                MemberID = member.MemberID,
                OrganizaionID = member.OrganizaionID,
                MemberSurname = member.MemberSurname,
                MemberName = member.MemberName
            };
            var membership = _context.Memberships.Where(m => m.MemberID == _member.MemberID).FirstOrDefault();
            var team = _context.Teams.Where(t => t.TeamID == membership.TeamID).FirstOrDefault();
            var organization = _context.Organizations.Where(t => t.OrganizationID == _member.MemberID).FirstOrDefault();
            if (organization.OrganizationID == team.OrganizaionID)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}