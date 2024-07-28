using BollywoodHubAPI.Data;
using BollywoodHubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BollywoodHubAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MoviesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllMovies() 
        {
            var allMovies = dbContext.Movie.ToList();
            return Ok(allMovies);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetMovieId(Guid id) 
        {
            var specificMovie = dbContext.Movie.Find(id);
            if (specificMovie == null) 
            {
                return NotFound();
            }
            return Ok(specificMovie);
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieDto AddMovieDto)
        {
            var movieEntity = new Models.Entities.Movies()
            {
                genre_ids = AddMovieDto.genre_ids,
                title = AddMovieDto.title,
                overview = AddMovieDto.overview,
                release_date = AddMovieDto.release_date,
                vote_average = AddMovieDto.vote_average,
                vote_count = AddMovieDto.vote_count,
                poster_path = AddMovieDto.poster_path,
                original_language = AddMovieDto.original_language,
            };

            dbContext.Movie.Add(movieEntity);
            dbContext.SaveChanges();
            return Ok();

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateMovie(Guid id, UpdateMovieDto updateMovieDto) 
        {
            var updateMovie  = dbContext.Movie.Find(id);
            if (updateMovie != null)
            {
                return NotFound();
            }
            updateMovie.genre_ids = updateMovieDto.genre_ids;
            updateMovie.title = updateMovieDto.title;
            updateMovie.overview = updateMovieDto.overview;
            updateMovie.release_date = updateMovieDto.release_date;
            updateMovie.vote_average = updateMovieDto.vote_average;
            updateMovie.vote_count = updateMovieDto.vote_count;
            updateMovie.poster_path = updateMovieDto.poster_path;
            updateMovie.original_language = updateMovieDto.original_language;

            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteMovie(Guid id) 
        { 
            var deleteMovie = dbContext.Movie.Find(id);
            if (deleteMovie != null)
            {
                return NotFound();
            }
            dbContext.Movie.Remove(deleteMovie);
            dbContext.SaveChanges();
            return Ok(); 
        }
    }
}
