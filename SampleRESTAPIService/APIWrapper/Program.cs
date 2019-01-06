using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using APIWrapper.Wrappers;
using APIWrapper.Model;
using AutoMapper;

namespace APIWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Just a test - Should display sample data of 4 films,
            
            // NOTE: The SampleRESTAPIService need to run on a separate Visual Studio Project.
            MyMovieAPIWrapper api = new MyMovieAPIWrapper();
            var rest = api.UpdateMovieDetailsByID(10, new Movie("1", "2", 51));

            //List<Movie> movies = new List<Movie>();
            //movies.Add(new Movie("j", "x,", 10));
            //movies.Add(new Movie("jz", "xz,", 9));
            //movies.Add(new Movie("jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj", "x,", 10));
            //var ret = api.AddMovies(movies);

            // Gets all the Movies by directly calling te SampleRESTAPIService.
            /*List<Movie> movies = api.GetAllMovies();

            foreach (Movie m in movies)
            {
                Console.WriteLine(m.SerializeToString());
            }*/
        }
    }
}
