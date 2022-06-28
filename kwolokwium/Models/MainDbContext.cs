using Microsoft.EntityFrameworkCore;

namespace kwolokwium.Models;

public class MainDbContext : DbContext
{
    
    public MainDbContext(DbContextOptions options) : base(options)
    {
    }

    protected MainDbContext()
    {
        
    }
    
    public DbSet<Member> Members { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<File> Files { get; set; }
   
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
   
        
           modelBuilder.Entity<Member>(m =>
           {
               m.HasKey(m => m.MemberID);
               m.HasOne(m => m.Organization).WithMany(o => o.Members).HasForeignKey(m => m.OrganizaionID).OnDelete(DeleteBehavior.NoAction);;
               m.Property(m => m.MemberName).IsRequired().HasMaxLength(20);
               m.Property(m => m.MemberSurname).IsRequired().HasMaxLength(50);
               m.Property(m => m.MemberNickname).HasMaxLength(20);

               m.HasData(
                   new Member()
                   {
                       MemberID = 11,
                       OrganizaionID = 20,
                       MemberName = "Nestor",
                       MemberSurname = "En bloque"
                   });
               
              
           });
          
            modelBuilder.Entity<Membership>(m =>
             {
                 
                 m.HasKey(m => new
                        {
                            m.MemberID,
                            m.TeamID
                        });
                 
                        m.HasOne(m => m.Member).WithMany(m => m.Memberships).HasForeignKey(m => m.MemberID).OnDelete(DeleteBehavior.NoAction);;
                        m.HasOne(m => m.Team).WithMany(t => t.Memberships).HasForeignKey(m => m.TeamID).OnDelete(DeleteBehavior.NoAction);
                        m.Property(m => m.MembershipDate).IsRequired();
                        
                        m.HasData(new Membership()
                        {
                            MemberID = 11,
                            TeamID = 22,
                            MembershipDate = DateTime.Parse("2022-03-21")
                        });
                     
             });
             
                modelBuilder.Entity<Team>(t =>
                  {
                      t.HasKey(t => t.TeamID);
                      t.HasOne(t => t.Organization).WithMany(o => o.Teams).HasForeignKey(t => t.OrganizaionID).OnDelete(DeleteBehavior.NoAction);;
                      t.Property(t => t.TeamName).IsRequired().HasMaxLength(50);
                      t.Property(t => t.TeamDescription).HasMaxLength(500);
 
                      t.HasData(new Team()
                      {
 
                          TeamID = 22,
                          OrganizaionID = 20,
                          TeamName = "losblocks",

                      });
 
                      
        });
                
                 
                    modelBuilder.Entity<Organization>(o =>
                    {
                        o.HasKey(o => o.OrganizationID);
                        o.Property(o => o.OrganizationName).IsRequired().HasMaxLength(100);
                        o.Property(o => o.OrganizationDomain).IsRequired().HasMaxLength(50);
                  

            
                        o.HasData(new Organization()
                        {
                            OrganizationID = 20,
                            OrganizationName = "ffff",
                            OrganizationDomain = "IT"
                          
                        });
                    }); 
                    
                    
                   modelBuilder.Entity<File>(f =>
                   {
                       f.HasKey(f => new
                       {
                           f.FileID,
                           f.TeamID
                       });
                       f.HasOne(f => f.Team).WithMany(t => t.Files).HasForeignKey(f => f.TeamID).OnDelete(DeleteBehavior.NoAction);;
                       f.Property(f => f.FileName).IsRequired().HasMaxLength(100);
                       f.Property(f => f.FileExtension).IsRequired().HasMaxLength(4);
                       f.Property(f => f.FileName).IsRequired();
                     
                       
                       f.HasData(
                           new File()
                           {
                               FileID = 99,
                               TeamID = 22,
                               FileName = "ufos-attack",
                               FileExtension = "txt",
                               FileSize = 3000
                               
                           });
                   });

                }
                
}