using kwolokwium.Controllers;
using Microsoft.EntityFrameworkCore;

namespace kwolokwium.Models;

public class MainDbContext : DbContext
{
    
    public MainDbContext(DbContextOptions options) : base(options)
    {
    }

//dotnet ef migrations add migracja
//dotnet database update
    protected MainDbContext()
    {
        
    }
    
  public DbSet<Album> Albums { get; set; }
    public DbSet<Musician> Musicians { get; set; }
    public DbSet<Musician_Track> MusicianTracks { get; set; }
    public DbSet<MusicLabel> MusicLabels { get; set; }
    public DbSet<Track> Tracks { get; set; }
   
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
   
           modelBuilder.Entity<Musician>(m =>
           {
               m.HasKey(m => m.IdMusician);
               m.Property(m => m.FirstName).IsRequired().HasMaxLength(30);
               m.Property(m => m.LastName).IsRequired().HasMaxLength(50);
               m.Property(m => m.Nickname).HasMaxLength(20);

               m.HasData(
                   new Musician
                   {
                       IdMusician = 11,
                       FirstName = "Nestor",
                       LastName = "En bloque"
                   });
           });
          
          modelBuilder.Entity<Musician_Track>(t =>
          {
              
              t.HasKey(t => new
                     {
                         t.IdTrack,
                         t.IdMusician
                     });
              
                     t.HasOne(t => t.Musician).WithMany(m => m.MusicianTracks).HasForeignKey(m => m.IdMusician);
                     t.HasOne(t => t.Track).WithMany(m => m.MusicianTracks).HasForeignKey(m => m.IdTrack);
         
                     t.HasData(new Musician_Track()
                     {
                         IdTrack = 666,
                         IdMusician = 11,
                     });
          });
          
          
     
         
           
                 modelBuilder.Entity<Track>(t =>
                 {
                     t.HasKey(t => t.IdTrack);
                     t.Property(t => t.TrackName).IsRequired().HasMaxLength(20);
                     t.Property(t => t.Duration).IsRequired();
                     t.HasOne(t => t.Album).WithMany(a => a.Tracks).HasForeignKey(t => t.IdMusicAlbum);

                     t.HasData(new Track()
                     {
                         
                     IdTrack = 666,
                     TrackName = "The beast",
                     Duration = 300f,
                     IdMusicAlbum = 333
                     
                     });
                                      
                 });
                
                    modelBuilder.Entity<Album>(a =>
                    {
                        a.HasKey(a => a.IdAlbum);
                        a.Property(a => a.AlbumName).IsRequired().HasMaxLength(30);
                        a.Property(a => a.PublishDate).IsRequired();
                        a.HasOne(a => a.MusicLabel).WithMany(a => a.Albums).HasForeignKey(a => a.IdMusicLabel);

            
                        a.HasData(new Album
                        {
                            IdAlbum = 333,
                            AlbumName = "Cumbias y HeavyMetal",
                            PublishDate = DateTime.Parse("2022-03-21"),
                            IdMusicLabel = 99
                        });
                    }); 
                    
                    modelBuilder.Entity<MusicLabel>(m =>
                    {
                        m.HasKey(m => m.IdMusicLabel);
                        m.Property(m => m.Name).IsRequired().HasMaxLength(50);
                     
                        m.HasData(
                            new MusicLabel
                            {
                                IdMusicLabel = 99,
                                Name = "UFO"
                             
                            });
                    });

                }
}