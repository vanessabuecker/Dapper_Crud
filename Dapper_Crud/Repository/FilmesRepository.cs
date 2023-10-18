using Dapper;
using Dapper_Crud.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static Azure.Core.HttpHeader;

namespace Dapper_Crud.Repository
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public FilmesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ServerConnection");
        }
        public async Task<Filmes> BuscaFilmeAsync(int id)
        {
            string sql =
                        @"SELECT
                            [FilmeID]
                           ,[Nome]
                           ,[DataLancamento]
                           ,[Nota]
                         FROM [DataMovies].[dbo].Filme
                         where FilmeID = @FilmeID";

            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Filmes>(sql, new { FilmeID = id });
        }

        public async Task<IEnumerable<Filmes>> BuscaFilmesAsync()
        {
            string sql = @"SELECT
                             [FilmeID]
                            ,[Nome]
                            ,[DataLancamento]
                            ,[Nota]
                         FROM [DataMovies].[dbo].Filme";

            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Filmes>(sql);
        }

        public async Task<bool> AdicionarFilmesRequest(FilmesRequest request)
        {
            string sql = @"INSERT INTO Filme ( Nome, DataLancamento, Nota)
                                Values (@Nome, @DataLancamento, @Nota)";

            using var connection = new SqlConnection(connectionString);
            return await connection.ExecuteAsync(sql, new { request.FilmeID, request.Nome, request.DataLancamento, request.Nota }) > 0;
        }

        public async Task<bool> AtualizarAsync(FilmesRequest request, int id)
        {
            string sql = @"UPDATE 
                            Filme SET Nome = @Nome,
                                  DataLancamento = @DataLancamento,
                                  Nota = @Nota
                                  where FilmeID = @FilmeID;";

            using var connection = new SqlConnection(connectionString);
            return await connection.ExecuteAsync(sql, new { request.FilmeID, request.Nome, request.DataLancamento, request.Nota }) > 0;
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
