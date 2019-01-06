using APIWrapper.Model;
using System.Collections.Generic;

namespace SampleRESTAPIService.SampleData
{
    public class APIWrapperValidation
    {
        public static List<string> ValidateMovieObject(Movie movie)
        {
            List<string> Errors = new List<string>();

            // Validation for name.
            if (movie.name.Length > 50)
            {
                Errors.Add(ErrorCodes.LIMIT_REACHED_FOR_NAME);
            }

            // Validation for genre.
            if (movie.genre.Length > 25)
            {
                Errors.Add(ErrorCodes.LIMIT_REACHED_FOR_GENRE);
            }

            // Validation for range.
            if (movie.rating > 10 || movie.rating < 0)
            {
                Errors.Add(ErrorCodes.OUT_OF_RANGE_RATING);
            }

            return Errors;
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
