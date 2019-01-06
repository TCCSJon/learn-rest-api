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
            allMovies.Add(new Movie(4, "The Shawshank Redemption", "Drame", 8));

            return allMovies;
        }
    }
}
