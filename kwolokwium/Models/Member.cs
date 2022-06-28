namespace kwolokwium.Models;

public class Member
{
    public int MemberID { get; set; }
    public int OrganizaionID { get; set; }
    public string MemberName { get; set; }
    public string MemberSurname { get; set; }
    public string? MemberNickname { get; set; }
    public virtual Organization Organization { get; set; }
    public virtual ICollection<Membership>? Memberships { get; set; }
}