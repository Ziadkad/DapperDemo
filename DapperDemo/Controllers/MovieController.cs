using DapperDemo.Entities;
using DapperDemo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie movie)
    {
        int result = await _movieRepository.AddMovie(movie);
        if (result > 0)
            return Ok();
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        IEnumerable<Movie> movies = await _movieRepository.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        Movie? movie = await _movieRepository.GetMovieById(id);
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie movie)
    {
        if (id != movie.Id)
            return BadRequest();
        
        int result = await _movieRepository.UpdateMovie(movie);
        if (result > 0)
            return NoContent();
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        int result = await _movieRepository.DeleteMovie(id);
        if (result > 0)
            return NoContent();
        return BadRequest();
    }
}