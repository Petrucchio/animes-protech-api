using Microsoft.AspNetCore.Mvc;
using AnimesProtech.Models;
using AnimesProtech.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;
        private readonly IAuthService _authService;

        public AnimeController(IAnimeService animeService, IAuthService authService)
        {
            _animeService = animeService;
            _authService = authService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarAnime([FromBody] Anime anime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var novoAnime = await _animeService.CadastrarAnime(anime);
            if (novoAnime == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetAnime), new { id = novoAnime.Id }, novoAnime);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAnime(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var anime = await _animeService.GetAnime(id);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAnimes(string diretor, string nome, string palavrasChave, int pagina = 1, int registrosPorPagina = 10)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var animes = await _animeService.GetAnimes(diretor, nome, palavrasChave, pagina, registrosPorPagina);
            return Ok(animes);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AtualizarAnime(int id, [FromBody] Anime anime)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var animeAtualizado = await _animeService.AtualizarAnime(id, anime);
            if (animeAtualizado == null)
            {
                return NotFound();
            }
            return Ok(animeAtualizado);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> ExcluirAnime(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var sucesso = await _animeService.ExcluirAnime(id);
            if (!sucesso)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
