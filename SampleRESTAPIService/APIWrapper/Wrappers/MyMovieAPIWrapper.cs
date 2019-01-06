using APIWrapper.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace APIWrapper.Wrappers
{
    public class MyMovieAPIWrapper : IMovieAPIWrapper
    {
        const string directURL = "https://localhost:44387/api/Movies";
        const string parametrisedURL = "https://localhost:44387/api/Movies/{0}";
        
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
        public void AddMovie(Movie movie)
        {
            var httpReq = HTTPHelper.CreateHTTPRequest(directURL, "POST");

            using (var streamWriter = new StreamWriter(httpReq.GetRequestStream()))
            {
                List<Movie> movies = new List<Movie>();
                movies.Add(movie);
                string json = JsonConvert.SerializeObject(movies.ToArray());

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
        }

        public void AddMovies(List<Movie> movies)
        {
            var httpReq = HTTPHelper.CreateHTTPRequest(directURL, "POST");

            using (var streamWriter = new StreamWriter(httpReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(movies.ToArray());
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpReq.GetResponse();
        }

        // Method for PUT
        public Movie UpdateMovieDetailsByID(long Id, Movie updatedMovie)
        {
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
