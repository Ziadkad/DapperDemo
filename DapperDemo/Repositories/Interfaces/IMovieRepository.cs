using DapperDemo.Entities;

namespace DapperDemo.Repositories.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllMovies();
    Task<Movie> GetMovieById(int id);
    Task<int> AddMovie(Movie movie);
    Task<int> UpdateMovie(Movie movie);
    Task<int> DeleteMovie(int id);
}