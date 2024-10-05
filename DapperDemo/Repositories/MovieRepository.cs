using Dapper;
using DapperDemo.Data;
using DapperDemo.Entities;
using DapperDemo.Repositories.Interfaces;

namespace DapperDemo.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly DatabaseConnection _dbConnection;

    public MovieRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        var query = "SELECT * FROM Movies";
        using (var connection = _dbConnection.CreateConnection())
        {
            return await connection.QueryAsync<Movie>(query);
        }
    }

    public async Task<Movie> GetMovieById(int id)
    {
        var query = "SELECT * FROM Movies WHERE Id = @Id";
        using (var connection = _dbConnection.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<Movie>(query, new { Id = id });
        }
    }

    public async Task<int> AddMovie(Movie movie)
    {
        var query = "INSERT INTO Movies (Title, Director, ReleaseDate, Genre, Duration) VALUES (@Title, @Director, @ReleaseDate, @Genre, @Duration)";
        using (var connection = _dbConnection.CreateConnection())
        {
            return await connection.ExecuteAsync(query, new { movie.Title, movie.Director, movie.ReleaseDate, movie.Genre, movie.Duration });
        }
    }
    
    public async Task<int> UpdateMovie(Movie movie)
    {
        var query = "UPDATE Movies SET Title = @Title, Director = @Director, ReleaseDate = @ReleaseDate, Genre = @Genre, Duration = @Duration WHERE Id = @Id";
        using (var connection = _dbConnection.CreateConnection())
        {
            return await connection.ExecuteAsync(query, new { movie.Title, movie.Director, movie.ReleaseDate, movie.Genre, movie.Duration, movie.Id });
        }
    }
    
    public async Task<int> DeleteMovie(int id)
    {
        var query = "DELETE FROM Movies WHERE Id = @Id";
        using (var connection = _dbConnection.CreateConnection())
        {
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
    
}