using System;
using System.Collections.Generic;
using kwolokwium.Controllers;

namespace kolokwium.Models.DTOs
{
    public class SomeKindOfAlbum
    {
        public string AlbumName { get; set; }
        public int idAlbum { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLable { get; set; }
        
        public MusicLabel MusicLabel { get; set; }

        public IEnumerable<SomeKindOfTrack> Tracks { get; set; }
    }
}
