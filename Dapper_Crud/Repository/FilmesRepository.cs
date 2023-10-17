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
                             FilmeID
                             Nome,
                             DataLancamento,
                             Nota
                         FROM dbo.Filme 
                         JOIN dbo.Usuario ON Filme.FilmeID = Usuario.UsuarioID;";

            using var connection = new SqlConnection(connectionString);
                return await connection.QueryAsync<Filmes>(sql);
        }

        public async Task<bool> AdicionarFilmesRequest(FilmesRequest request)
        {
            string sql = @"INSERT INTO Filme ( Nome, DataLancamento, Nota)
                                Values (@Nome, @DataLancamento, @Nota)";

            using var connection = new SqlConnection(connectionString);
            return await connection.ExecuteAsync(sql, new { Nome = request.Name, DataLancamento = request.DataLancamento, Nota = request.Nota }) > 0;
        }

        public Task<bool> AtualizarAsync(FilmesRequest request, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
