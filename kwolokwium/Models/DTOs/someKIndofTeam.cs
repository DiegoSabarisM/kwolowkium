using kwolokwium.Models;

namespace kwolokwium.Controllers.DTOs;

public class someKIndofTeam
{
    public int TeamID { get; set; }
    public int OrganizaionID { get; set; }
    public string TeamName { get; set; }
    public string? TeamDescription { get; set; }
    public virtual someKindofOrganization? Organization { get; set; }
    public virtual ICollection<someKindofMembership>? Memberships { get; set; }  


}