using Azure.Core;
using Dapper_Crud.Models;
using Dapper_Crud.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Dapper_Crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmesRepository _repository;

        public FilmesController(IFilmesRepository repository)
        {
            _repository = repository;
        }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var filmes = await _repository.BuscaFilmesAsync();

                return filmes.Any() ? Ok(filmes) : NoContent();
            }

            [HttpGet("id")]
            public async Task<IActionResult> Get(int id)
            {
                var filme = await _repository.BuscaFilmeAsync(id);

                return filme != null ? Ok(filme) : NotFound("Filme nao encontrado");
            }

            [HttpPost]
            public async Task<IActionResult> Post(FilmesRequest request)
            {
            if (string.IsNullOrEmpty(request.Nome))
            {
                return BadRequest("Valor incorreto.");
            }
            var adicionado = await _repository.AdicionarFilmesRequest(request);

            return adicionado ? Ok("Filme adicionado com sucesso")
                : BadRequest("Erro ao adicionar filme");
            }

            [HttpPut]
            public async Task<IActionResult> Put(FilmesRequest request, int id)
            {
            if (id <= 0) 
            {
                return BadRequest("Valor incorreto.");
            }
            var filme = await _repository.BuscaFilmeAsync(id);
            if (filme == null)
            {
                return NotFound("Filme não encontrado.");
            }
            if (string.IsNullOrEmpty(request?.Nome))
            {
                request.Nome = filme.Nome;
            }
            var atualizado = await _repository.AtualizarAsync(request, id);
            return atualizado ? Ok("Filme adicionado com sucesso")
                : BadRequest("Erro ao adicionar filme");
        }
    }
    
    }
