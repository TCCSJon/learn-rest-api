using APIWrapper.Model;
using Newtonsoft.Json;
using SampleRESTAPIService.SampleData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace APIWrapper.Wrappers
{
    /// <summary>
    /// This is a wrapper class to pull data from the Rest API.
    /// </summary>
    public class MyMovieAPIWrapper : IMovieAPIWrapper
    {
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // NOTE START!!: THE PORT WOULD NEED TO BE CHANGED ACCORDING TO THE PORT NUMBER THAT IS GENERATED WHEN RUNNING THE 'SAMPLERESTAPISERVICE'
        const string directURL = "https://localhost:44387/api/Movies";
        const string parametrisedURL = "https://localhost:44387/api/Movies/{0}";
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public MyMovieAPIWrapper() { }

        // Method for GET
        public List<Movie> GetAllMovies()
        {
            var httpReq = HTTPHelper.CreateHTTPRequest(directURL, "GET");

            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Movie>>(result);
            }
        }

        public Movie GetMovieByID(long Id)
        {
            string formattedURL = String.Format(parametrisedURL, Id);
            var httpReq = HTTPHelper.CreateHTTPRequest(formattedURL, "GET");
            
            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Movie>(result);
            }
        }

        // Method for POST
        public Movie AddMovie(Movie movie)
        {
            List<string> errors = APIWrapperValidation.ValidateMovieObject(movie);

            // If there are any validation errors, do not perform an HTTP request.
            if (errors.Count > 0)
            {
                return null;
            }

            var httpReq = HTTPHelper.CreateHTTPRequest(directURL, "POST");

            using (var streamWriter = new StreamWriter(httpReq.GetRequestStream()))
            {
                List<Movie> movies = new List<Movie>();
                movies.Add(movie);
                string json = JsonConvert.SerializeObject(movies.ToArray());

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
            return movie;
        }

        public List<Movie> AddMovies(List<Movie> movies)
        {
            bool bCorrectValidation = true;

            movies.ForEach(m =>
            {
                if (APIWrapperValidation.ValidateMovieObject(m).Count > 0)
                {
                    bCorrectValidation = false;
                    // Invalidated the movies passed.
                    movies = null;
                    return;
                }
            });

            if (bCorrectValidation)
            {
                var httpReq = HTTPHelper.CreateHTTPRequest(directURL, "POST");

                using (var streamWriter = new StreamWriter(httpReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(movies.ToArray());
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpReq.GetResponse();
            }

            return movies;
        }

        // Method for PUT
        public Movie UpdateMovieDetailsByID(long Id, Movie updatedMovie)
        {
            List<string> errors = APIWrapperValidation.ValidateMovieObject(updatedMovie);

            // If there are any validation errors, do not perform an HTTP request.
            // Also, dont perform any update if the movie with the ID does not exist.
            if (errors.Count > 0 || GetMovieByID(Id) == null)
            {
                return null;
            }

            string formattedURL = String.Format(parametrisedURL, Id);
            var httpReq = HTTPHelper.CreateHTTPRequest(formattedURL, "PUT");

            using (var streamWriter = new StreamWriter(httpReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(updatedMovie);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                
                // Returning the updated Movie.
                Movie movie = JsonConvert.DeserializeObject<Movie>(result);

                if (movie == null)
                {
                    movie.ErrorList.Add("Error occured while updating the movie.");
                }

                return movie;
            }
        }

        // Method for DELETE
        public void DeleteMovieById(long Id)
        {
            string formatedURL = String.Format(parametrisedURL, Id);
            var httpReq = HTTPHelper.CreateHTTPRequest(formatedURL, "DELETE");
            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
        }
    }
}
