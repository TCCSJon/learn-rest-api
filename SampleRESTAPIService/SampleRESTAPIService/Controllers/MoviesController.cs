using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPIService.SampleData;

namespace SampleRESTAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        List<Movie> movies = DataAccessor.Instance.GetMovies();

        // GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return movies.Where(m => !m.isDeleted()).ToList();
        }

        // GET api/movies/
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return movies.FirstOrDefault(m => m.GetID() == id);
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody] Movie[] values)
        {
            foreach (Movie value in values)
            {
                // Add a Move to the list.
                Movie newMovie = new Movie(value.name, value.genre, value.rating);
                newMovie.SetID(movies.Select(m => m.GetID()).Max() + 1);
                movies.Add(newMovie);
            }
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public Movie Put(int id, [FromBody] Movie updatedValue)
        {
            updatedValue.SetID(id);
            Movie updatedMovie = movies.FirstOrDefault(m => m.GetID() == id);
            movies.Remove(updatedMovie);
            movies.Add(updatedValue);
            return updatedValue;
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movie updatedMovie = movies.FirstOrDefault(m => m.GetID() == id && !m.isDeleted());

            // Enter this section only if the movie wasnt already deleted.
            if (updatedMovie != null)
            {
                movies.Remove(updatedMovie);
                updatedMovie.DeleteMovie();
                movies.Add(updatedMovie);
            }
        }
    }
}