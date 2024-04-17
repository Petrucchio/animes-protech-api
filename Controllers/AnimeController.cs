using Microsoft.AspNetCore.Mvc;
using AnimesProtech.Models;
using AnimesProtech.Services;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService; 

        public AnimeController(IAnimeService animeService) 
        {
            _animeService = animeService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnime([FromBody] Anime anime)
        {
            var novoAnime = await _animeService.CadastrarAnime(anime);
            return CreatedAtAction(nameof(GetAnime), new { id = novoAnime.Id }, novoAnime);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnime(int id)
        {
            var anime = await _animeService.GetAnime(id);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimes(string diretor, string nome, string palavrasChave, int pagina = 1, int registrosPorPagina = 10)
        {
            var animes = await _animeService.GetAnimes(diretor, nome, palavrasChave, pagina, registrosPorPagina);
            return Ok(animes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAnime(int id, [FromBody] Anime anime)
        {
            var animeAtualizado = await _animeService.AtualizarAnime(id, anime);
            if (animeAtualizado == null)
            {
                return NotFound();
            }
            return Ok(animeAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAnime(int id)
        {
            var sucesso = await _animeService.ExcluirAnime(id);
            if (!sucesso)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
