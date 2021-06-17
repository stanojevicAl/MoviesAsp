using Bogus;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertAllController : ControllerBase
    {
        // POST api/<InsertAllController>
        [HttpPost]
        public IActionResult Post()
        {
            var _context = new Context(); 

            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin"
                }, new Role
                {
                    Name = "User"
                }
            };

            var usersFaker = new Faker<User>();
            usersFaker.RuleFor(x => x.Name, f => f.Name.FirstName());
            usersFaker.RuleFor(x => x.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(x => x.Username, f => f.Internet.UserName());
            usersFaker.RuleFor(x => x.Email, f => f.Internet.Email());
            usersFaker.RuleFor(x => x.Password, f => "sifra1");
            usersFaker.RuleFor(x => x.Role, f => f.PickRandom(roles));
            usersFaker.RuleFor(x => x.Verification, f => true);

            var users = usersFaker.Generate(15);

            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Action"
                },
                new Genre
                {
                    Name = "Drama"
                },new Genre
                {
                    Name = "Horor"
                },
                new Genre
                {
                    Name = "Thriler"
                },
                new Genre
                {
                    Name = "Romanse"
                },
                new Genre
                {
                    Name = "Sci-fi"
                },
                new Genre
                {
                    Name = "Adventure"
                }
            };


            var actorsFaker = new Faker<Actor>();
            actorsFaker.RuleFor(x => x.Name, f => f.Name.FirstName());
            actorsFaker.RuleFor(x => x.LastName, f => f.Name.LastName());

            var actors = actorsFaker.Generate(20);
            Random r = new Random();
            var movies = new List<Movie>
            {
                new Movie
                {
                    Name = "Film 1",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2015,
                    Link = "link1",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    MovieComments = new List<MovieComment>
                    {
                        new MovieComment
                        {
                            User = users.First(),
                            Comment = "Dobar film",
                            CommentDate = DateTime.Now
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 2",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2015,
                    Link = "link2",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 3",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2015,
                    Link = "link3",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    MovieComments = new List<MovieComment>
                    {
                        new MovieComment
                        {
                            User = users.Last(),
                            Comment = "Okej film",
                            CommentDate = DateTime.Now
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 4",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2020,
                    Link = "link4",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    UserFavorites = new List<UserFavorite>
                    {
                        new UserFavorite
                        {
                            User = users.First()
                        },
                        new UserFavorite
                        {
                            User = users.Last()
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 5",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2018,
                    Link = "link5",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 6",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2014,
                    Link = "link6",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    },
                    UserFavorites = new List<UserFavorite>
                    {
                        new UserFavorite
                        {
                            User = users.Last()
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 7",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2015,
                    Link = "link7",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 8",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2015,
                    Link = "link8",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 9",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2010,
                    Link = "link9",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                },
                new Movie
                {
                    Name = "Film 10",
                    Description = "Opis",
                    Duration = 120,
                    Year = 2008,
                    Link = "link10",
                    Image = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    CoverImage = "602610ae-71e0-4c56-99a7-287bc6bd8281.jpg",
                    MovieActors = new List<MovieActor>
                    {
                        new MovieActor
                        {
                            Actor = actors.First()
                        },
                        new MovieActor
                        {
                            Actor = actors.Last()
                        }
                    },
                    MovieGenres = new List<MovieGenre>
                    {
                        new MovieGenre
                        {
                            Genre = genres.First()
                        },
                        new MovieGenre
                        {
                            Genre = genres.Last()
                        }
                    },
                    MovieRatings = new List<MovieRating>
                    {
                        new MovieRating
                        {
                            User = users.First(),
                            Rating = r.Next(1, 10)
                        },
                        new MovieRating
                        {
                            User = users.Last(),
                            Rating = r.Next(1, 10)
                        }
                    }

                }
            };

            _context.Users.AddRange(users);
            _context.Actors.AddRange(actors);
            _context.Genres.AddRange(genres);
            _context.Movies.AddRange(movies);
            try
            {
                _context.SaveChanges();
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

    }
}
