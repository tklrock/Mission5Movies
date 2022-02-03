using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5Movies.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<MovieEntry> Responses { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Available categories for movies
            mb.Entity<MovieCategory>().HasData(
                new MovieCategory { CategoryId = 1, CategoryName = "Action/Adventure" },
                new MovieCategory { CategoryId = 2, CategoryName = "Comedy" },
                new MovieCategory { CategoryId = 3, CategoryName = "Drama" },
                new MovieCategory { CategoryId = 4, CategoryName = "Family" },
                new MovieCategory { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new MovieCategory { CategoryId = 6, CategoryName = "Miscellaneous" },
                new MovieCategory { CategoryId = 7, CategoryName = "Television" },
                new MovieCategory { CategoryId = 8, CategoryName = "VHS" }
            );
            //Initial movie entires into the database
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Interstellar",
                    Year = 2015,
                    Director = "Christpoher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Top 10"
                }
            );
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Umbrellas of Cherbourg",
                    Year = 1964,
                    Director = "Jacques Demy",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Keanna",
                    Notes = "Top 5"
                }
            );
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "Tick, Tick... Boom!",
                    Year = 2021,
                    Director = "Lin-Manuel Miranda",
                    Rating = "UR",
                    Edited = false,
                    LentTo = "",
                    Notes = "Top 20"
                }
            );
        }
    }
}
