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

            // Gets all the Movies by directly calling te SampleRESTAPIService.
            List<Movie> movies = api.GetAllMovies();

            foreach (Movie m in movies)
            {
                Console.WriteLine(m.SerializeToString());
            }
        }
    }
}
