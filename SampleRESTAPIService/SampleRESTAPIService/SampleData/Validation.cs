using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPIService.SampleData
{
    public class Validation
    {
        public List<string> ValidateMovieObject(Movie movie)
        {
            List<string> rError = new List<string>();

            // Validation for name.
            if (movie.name.Length > 50)
            {
                rError.Add(ErrorCodes.LIMIT_REACHED_FOR_NAME);
            }

            // Validation for genre.
            if (movie.genre.Length > 25)
            {
                rError.Add(ErrorCodes.LIMIT_REACHED_FOR_GENRE);
            }

            // Validation for range.
            if (movie.rating > 10 || movie.rating < 0)
            {
                rError.Add(ErrorCodes.OUT_OF_RANGE_RATING);
            }

            // Validation for Id.
            if (DataAccessor.Instance.GetMovies().Any(m => m.GetID() == movie.GetID()))
            {
                rError.Add(ErrorCodes.ID_ALREADY_EXISTS);
            }

            return rError;
        }
    }

    public static class ErrorCodes
    {
        public const string LIMIT_REACHED_FOR_NAME = "Name must not exceed 50 characters.\n";
        public const string LIMIT_REACHED_FOR_GENRE = "Genre must not exceed 50 characters.\n";
        public const string OUT_OF_RANGE_RATING = "Movie rating must be a number between 0 to 10 (both inclusive).\n";
        public const string ID_ALREADY_EXISTS = "Movie ID already exists.";
    }
}
