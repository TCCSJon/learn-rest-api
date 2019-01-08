using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPIService.SampleData
{
    public class MovieData
    {
        public List<Movie> LoadDefaultData()
        {
            List<Movie> allMovies = new List<Movie>();

            // Get rid of all the data.
            allMovies.Clear();

            allMovies.Add(new Movie(1, "Home Alone", "Comedy, Family", 6));
            allMovies.Add(new Movie(2, "Jumanji", "Fantasy, Family", 4));
            allMovies.Add(new Movie(3, "Taken 1", "Action", 5));
            allMovies.Add(new Movie(4, "The Shawshank Redemption", "Drama", 8));
            allMovies.Add(new Movie(5, "The Day After Tomorrow", "Action", 9));
            allMovies.Add(new Movie(6, "Pearl Harbour", "Romance, Action", 9));
            allMovies.Add(new Movie(7, "Titanic", "Romance", 5));
            allMovies.Add(new Movie(8, "Final Fantasy", "Fantasy", 6));
            allMovies.Add(new Movie(9, "Final Destination 1", "Action", 7));
            allMovies.Add(new Movie(10, "Final Destination 2", "Action", 6));
            allMovies.Add(new Movie(11, "Final Destination 3", "Action", 5));
            allMovies.Add(new Movie(12, "Final Destination 4", "Action", 4));
            allMovies.Add(new Movie(13, "Bohemian Rhapsody", "Drama", 10));
            allMovies.Add(new Movie(14, "Love Actually", "Romance", 4));
            allMovies.Add(new Movie(15, "Exorcist", "Horror", 8));
            allMovies.Add(new Movie(16, "Fantastic 4", "Action", 4));
            allMovies.Add(new Movie(17, "X-Men 1", "Action", 7));
            allMovies.Add(new Movie(18, "X-Men 2", "Action", 7));
            allMovies.Add(new Movie(19, "Wolverine", "Action", 7));
            allMovies.Add(new Movie(20, "San Andreas", "Action", 7));

            return allMovies;
        }
    }
}
