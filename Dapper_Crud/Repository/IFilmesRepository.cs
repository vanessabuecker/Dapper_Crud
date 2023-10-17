using Dapper_Crud.Models;

namespace Dapper_Crud.Repository
{
    public interface IFilmesRepository
    {
        Task<IEnumerable<Filmes>> BuscaFilmesAsync();
        Task<Filmes> BuscaFilmeAsync(int id);
        Task<bool> AdicionarFilmesRequest(FilmesRequest request);
        Task<bool> AtualizarAsync(FilmesRequest request, int id);
        Task<bool> DeletarAsync(int id);




    }
}
