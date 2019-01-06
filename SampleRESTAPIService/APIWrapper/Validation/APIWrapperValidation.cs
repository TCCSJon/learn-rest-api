using APIWrapper.Model;

namespace SampleRESTAPIService.SampleData
{
    public class APIWrapperValidation
    {
        public static string ValidateMovieObject(Movie movie)
        {
            string rError = string.Empty;

            // Validation for name.
            if (movie.name.Length > 50)
            {
                rError += ErrorCodes.LIMIT_REACHED_FOR_NAME;
            }

            // Validation for genre.
            if (movie.genre.Length > 25)
            {
                rError += ErrorCodes.LIMIT_REACHED_FOR_GENRE;
            }

            // Validation for range.
            if (movie.rating > 10 || movie.rating < 0)
            {
                rError += ErrorCodes.OUT_OF_RANGE_RATING;
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
