﻿using APIWrapper.Model;
using System.Collections.Generic;

namespace APIWrapper.Wrappers
{
    interface IMovieAPIWrapper
    {
        // Methods for GET
        List<Movie> GetAllMovies();
        Movie GetMovieByID(long Id);

        // Methods for POST
        Movie AddMovie(Movie movie);
        List<Movie> AddMovies(List<Movie> movies);

        // Method for PUT
        Movie UpdateMovieDetailsByID(long Id, Movie updatedMovie);

        // Method for DELETE
        void DeleteMovieById(long Id);
    }
}
