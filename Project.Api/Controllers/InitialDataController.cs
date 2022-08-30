using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        public ProjectDbContext context { get; set; }
        public InitialDataController(ProjectDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post()
        {
            if (context.Users.Any())
            {
                return Conflict("Inital data already exist in system.");
            }

            var genres = new List<Genre>
            {
                new Genre { Name = "Rock"}, 
                new Genre { Name = "Pop"}, 
                new Genre { Name = "Hip Hop"}, 
                new Genre { Name = "Heavy Metal"},
                new Genre { Name = "Folk"},
                new Genre { Name = "Soul Music"},
                new Genre { Name = "R&B"},
                new Genre { Name = "Latino Urbano"},
            };
            var users = new List<User>
            {
                new User { Firstname = "User", Lastname = "Admin", Email = "admin@gmail.com", Username = "adminuser", Password = BCrypt.Net.BCrypt.HashPassword("lozinka123*") },
                new User { Firstname = "Marko", Lastname = "Markovic", Email = "marko@gmail.com", Username = "mmarkovic", Password = BCrypt.Net.BCrypt.HashPassword("lozinka123*") },
                new User { Firstname = "Petar", Lastname = "Petrovic", Email = "petar@gmail.com", Username = "ppetrovic", Password = BCrypt.Net.BCrypt.HashPassword("lozinka123*") }
            };
            var songs = new List<Song>
            {
                new Song { Name = "Hello", Duration = "4:55"},
                new Song { Name = "When We Were Young", Duration = "4:51" },
                new Song { Name = "I Miss You", Duration = "5:49" },
                new Song { Name = "Sweetest Devotion", Duration = "4:12" },
                new Song { Name = "Inaders", Duration = "3:24" },
                new Song { Name = "Run To The Hills", Duration = "3:54" },
                new Song { Name = "The Prisoner", Duration = "6:02" },
                new Song { Name = "The Number Of The Beast", Duration = "4:51" },
                new Song { Name = "Gangland", Duration = "3:49" },
                new Song { Name = "Children Of The Damned", Duration = "4:35" },
                new Song { Name = "El Perdedor", Duration = "3:27" },
                new Song { Name = "Una aventura", Duration = "3:41" },
                new Song { Name = "Solos", Duration = "3:27" },
                new Song { Name = "Vente Pa' Ca", Duration = "3:27" },
                new Song { Name = "Shallow", Duration = "3:00" },
                new Song { Name = "La vie en rose", Duration = "3:00" },
                new Song { Name = "Black Eyes", Duration = "3:04" },
                new Song { Name = "Say Say say", Duration = "3:42" }, 
                new Song { Name = "There Must Be More To Life Than This", Duration = "2:54" },
                new Song { Name = "The Girl is Mine", Duration = "3:22" },
                new Song { Name = "Side To Side", Duration = "3:46" },
                new Song { Name = "Leave Me Lonely", Duration = "3:50" },
                new Song { Name = "Into You", Duration = "4:05" },
                new Song { Name = "Dangerous Woman", Duration = "3:56" },
                new Song { Name = "Moonlight", Duration = "3:22" },
                new Song { Name = "7 rings", Duration = "3:22" },
                new Song { Name = "Break Up With Your Girlfriend", Duration = "3:11" },
                new Song { Name = "Thank U, Next", Duration = "3:27" },
                new Song { Name = "Bad Idea", Duration = "4:27" },
                new Song { Name = "Heartless", Duration = "3:18" }, 
                new Song { Name = "Blinding Lights", Duration = "3:20" },
                new Song { Name = "In Your Eyes", Duration = "3:58" },
                new Song { Name = "Alone Again", Duration = "4:10" },
                new Song { Name = "Faith", Duration = "4:43" },
                new Song { Name = "Hawai", Duration = "4:21" },
                new Song { Name = "Call Out My Name", Duration = "3:48" },
                new Song { Name = "Wasted Times", Duration = "3:40" },
                new Song { Name = "Hurt You", Duration = "3:50" },
                new Song { Name = "Try Me", Duration = "3:41" },
                new Song { Name = "I Was Never There", Duration = "4:01" },
                new Song { Name = "Privilege", Duration = "2:51" }
            };
            var artists = new List<Artist>
            {
                new Artist { Fullname = "ACDC"},
                new Artist { Fullname = "Adele"},
                new Artist { Fullname = "Britney Spears"},
                new Artist { Fullname = "Maluma"},
                new Artist { Fullname = "Iron Maiden"},
                new Artist { Fullname = "Ricky Martin"},
                new Artist { Fullname = "Bradley Cooper"},
                new Artist { Fullname = "Michael Jackson"},
                new Artist { Fullname = "Paul McCartney"},
                new Artist { Fullname = "Ariana Grande"},
                new Artist { Fullname = "The Weeknd"},
                new Artist { Fullname = "Lady Gaga"},
                new Artist { Fullname = "Freddie Mercury"},
            };
            var albums = new List<Album>
            {
                new Album { Name = "25",  Published = new DateTime(2015, 11, 20), Price = 9.80m,Songs = songs.GetRange(0,4), Artist = artists.ElementAt(1)},
                new Album { Name = "The Number of the Beast",  Published = new DateTime(1982, 3, 22), Price = 9.99m, Songs= songs.GetRange(4,6),Artist = artists.ElementAt(4) },
                new Album { Name = "Pretty Boy, Dirty Boy",  Published = new DateTime(2015, 10, 30), Price = 45.82m, Songs= songs.GetRange(10,4), Artist = artists.ElementAt(3) },
                new Album { Name = "A Star Is Born",  Published = new DateTime(2018, 10, 5), Price = 12.94m, Songs= songs.GetRange(14,3), Artist = artists.ElementAt(11) },
                new Album { Name = "Thriller",  Published = new DateTime(1982, 11, 30), Price = 26.27m, Songs= songs.GetRange(17,1) , Artist = artists.ElementAt(7)},
                new Album { Name = "Pipes Of Peace",  Published = new DateTime(1983, 10, 31), Price = 11.99m, Songs= songs.GetRange(18,1), Artist = artists.ElementAt(7) },
                new Album { Name = "Mr. Bad Guy",  Published = new DateTime(1985, 4, 29), Price = 18.89m, Songs= songs.GetRange(19,1), Artist = artists.ElementAt(12) },
                new Album { Name = "Dangerous Woman",  Published = new DateTime(2016, 5, 20), Price = 7.99m, Songs= songs.GetRange(20,5), Artist = artists.ElementAt(9) },
                new Album { Name = "Thank U, Next",  Published = new DateTime(2019, 2, 8), Price = 11.49m, Songs= songs.GetRange(25,4), Artist = artists.ElementAt(9) },
                new Album { Name = "After Hours",  Published = new DateTime(2020, 3, 20), Price = 11.99m, Songs= songs.GetRange(29,6), Artist = artists.ElementAt(10) },
                new Album { Name = "My Dear Melancholy",  Published = new DateTime(2018, 3, 30), Price = 6.87m, Songs= songs.GetRange(35,6), Artist = artists.ElementAt(10) }
            };
            var songArtist = new List<SongArtist>
            {
                new SongArtist { Artist = artists.ElementAt(1), Song = songs.ElementAt(0)},
                new SongArtist { Artist = artists.ElementAt(1), Song = songs.ElementAt(1)},
                new SongArtist { Artist = artists.ElementAt(1), Song = songs.ElementAt(2)},
                new SongArtist { Artist = artists.ElementAt(1), Song = songs.ElementAt(3)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(4)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(5)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(6)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(7)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(8)},
                new SongArtist { Artist = artists.ElementAt(4), Song = songs.ElementAt(9)},
                new SongArtist { Artist = artists.ElementAt(3), Song = songs.ElementAt(10)},
                new SongArtist { Artist = artists.ElementAt(3), Song = songs.ElementAt(11)},
                new SongArtist { Artist = artists.ElementAt(3), Song = songs.ElementAt(12)},
                new SongArtist { Artist = artists.ElementAt(3), Song = songs.ElementAt(13)},
                new SongArtist { Artist = artists.ElementAt(5), Song = songs.ElementAt(13)},
                new SongArtist { Artist = artists.ElementAt(6), Song = songs.ElementAt(14)},
                new SongArtist { Artist = artists.ElementAt(11), Song = songs.ElementAt(14)},
                new SongArtist { Artist = artists.ElementAt(11), Song = songs.ElementAt(15)},
                new SongArtist { Artist = artists.ElementAt(11), Song = songs.ElementAt(16)},
                new SongArtist { Artist = artists.ElementAt(12), Song = songs.ElementAt(18)},
                new SongArtist { Artist = artists.ElementAt(7), Song = songs.ElementAt(18)},
                new SongArtist { Artist = artists.ElementAt(7), Song = songs.ElementAt(17)},
                new SongArtist { Artist = artists.ElementAt(8), Song = songs.ElementAt(17)},
                 new SongArtist { Artist = artists.ElementAt(7), Song = songs.ElementAt(19)},
                new SongArtist { Artist = artists.ElementAt(8), Song = songs.ElementAt(19)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(20)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(21)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(22)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(23)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(24)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(25)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(26)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(27)},
                new SongArtist { Artist = artists.ElementAt(9), Song = songs.ElementAt(28)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(29)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(30)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(31)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(32)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(33)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(34)},
                new SongArtist { Artist = artists.ElementAt(3), Song = songs.ElementAt(34)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(35)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(36)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(37)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(38)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(39)},
                new SongArtist { Artist = artists.ElementAt(10), Song = songs.ElementAt(40)}
            };
            var albumGenres = new List<AlbumGenre>
            {
                new AlbumGenre { Album = albums.ElementAt(0), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(0), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(0), Genre = genres.ElementAt(4)},
                new AlbumGenre { Album = albums.ElementAt(0), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(1), Genre = genres.ElementAt(0)},
                new AlbumGenre { Album = albums.ElementAt(1), Genre = genres.ElementAt(3)},
                new AlbumGenre { Album = albums.ElementAt(2), Genre = genres.ElementAt(7)},
                new AlbumGenre { Album = albums.ElementAt(2), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(3), Genre = genres.ElementAt(0)},
                new AlbumGenre { Album = albums.ElementAt(3), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(3), Genre = genres.ElementAt(4)},
                new AlbumGenre { Album = albums.ElementAt(4), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(4), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(4), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(5), Genre = genres.ElementAt(0)},
                new AlbumGenre { Album = albums.ElementAt(5), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(5), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(5), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(6), Genre = genres.ElementAt(0)},
                new AlbumGenre { Album = albums.ElementAt(6), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(6), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(6), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(7), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(7), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(7), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(8), Genre = genres.ElementAt(2)},
                new AlbumGenre { Album = albums.ElementAt(8), Genre = genres.ElementAt(1)},
                new AlbumGenre { Album = albums.ElementAt(8), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(9), Genre = genres.ElementAt(5)},
                new AlbumGenre { Album = albums.ElementAt(9), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(10), Genre = genres.ElementAt(6)},
                new AlbumGenre { Album = albums.ElementAt(10), Genre = genres.ElementAt(5)}
            };
            var likes = new List<Like>
            {
                new Like { Album = albums.ElementAt(0), User = users.ElementAt(1)},
                new Like { Album = albums.ElementAt(5), User = users.ElementAt(1)},
                new Like { Album = albums.ElementAt(6), User = users.ElementAt(1)},
                new Like { Album = albums.ElementAt(9), User = users.ElementAt(2)},
                new Like { Album = albums.ElementAt(10), User = users.ElementAt(2)},
            };

            var useCases = new List<UseCase>
            {
                #region Admin
                new UseCase { User = users.First(), UseCaseID = 1 },
                new UseCase { User = users.First(), UseCaseID = 2 },
                new UseCase { User = users.First(), UseCaseID = 3 },
                new UseCase { User = users.First(), UseCaseID = 4 },
                new UseCase { User = users.First(), UseCaseID = 5 },
                new UseCase { User = users.First(), UseCaseID = 6 },
                new UseCase { User = users.First(), UseCaseID = 7 },
                new UseCase { User = users.First(), UseCaseID = 8 },
                new UseCase { User = users.First(), UseCaseID = 9 },
                new UseCase { User = users.First(), UseCaseID = 10 },
                new UseCase { User = users.First(), UseCaseID = 12 },
                new UseCase { User = users.First(), UseCaseID = 13 },
                new UseCase { User = users.First(), UseCaseID = 14 },
                new UseCase { User = users.First(), UseCaseID = 15 },
                new UseCase { User = users.First(), UseCaseID = 16 },
                new UseCase { User = users.First(), UseCaseID = 17 },
                new UseCase { User = users.First(), UseCaseID = 18 },
                new UseCase { User = users.First(), UseCaseID = 20 },
                new UseCase { User = users.First(), UseCaseID = 21 },
                new UseCase { User = users.First(), UseCaseID = 22 },
                new UseCase { User = users.First(), UseCaseID = 23 },
                new UseCase { User = users.First(), UseCaseID = 24 },
                new UseCase { User = users.First(), UseCaseID = 25 },
                new UseCase { User = users.First(), UseCaseID = 26 },
                new UseCase { User = users.First(), UseCaseID = 29 },
                new UseCase { User = users.First(), UseCaseID = 30 },
                new UseCase { User = users.First(), UseCaseID = 31 },
	            #endregion
                new UseCase { User = users.ElementAt(1), UseCaseID = 2 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 3 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 7 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 8 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 12 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 13 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 14 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 15 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 27 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 28 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 11 },
                new UseCase { User = users.ElementAt(1), UseCaseID = 19 },

                new UseCase { User = users.ElementAt(2), UseCaseID = 2 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 3 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 7 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 8 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 12 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 13 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 14 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 15 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 27 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 28 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 11 },
                new UseCase { User = users.ElementAt(2), UseCaseID = 19 },

            };

            context.Genres.AddRange(genres);
            context.Users.AddRange(users);
            context.Songs.AddRange(songs);
            context.Albums.AddRange(albums);
            context.Artists.AddRange(artists);
            context.SongArtists.AddRange(songArtist);
            context.AlbumGenres.AddRange(albumGenres);
            context.Likes.AddRange(likes);
            context.UseCases.AddRange(useCases);
            context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
