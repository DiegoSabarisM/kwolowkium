namespace kwolokwium.Controllers.DTOs;

public class someKindofOrganization
{
  public int OrganizationID { get; set; }
    public string OrganizationName { get; set; }
    public string OrganizationDomain { get; set; }
    public virtual ICollection<someKindofMember>? Members { get; set; }
 
}