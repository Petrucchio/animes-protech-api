using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimesProtech.Data;
using AnimesProtech.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;

        public AnimeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Anime> CadastrarAnime(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<bool> ExcluirAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
                return false;

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Anime> GetAnime(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<IEnumerable<Anime>> GetAnimes(string diretor, string nome, string palavrasChave, int pagina, int registrosPorPagina)
        {
            IQueryable<Anime> query = _context.Animes;

            if (!string.IsNullOrWhiteSpace(diretor))
                query = query.Where(a => a.Diretor.Contains(diretor));

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(a => a.Nome.Contains(nome));

            if (!string.IsNullOrWhiteSpace(palavrasChave))
                query = query.Where(a => a.Resumo.Contains(palavrasChave));

            return await query.Skip((pagina - 1) * registrosPorPagina)
                              .Take(registrosPorPagina)
                              .ToListAsync();
        }

        public async Task<Anime> AtualizarAnime(int id, Anime anime)
        {
            if (id <= 0)
            {
                return null; 
            }

            var animeExistente = await _context.Animes.FindAsync(id);
            if (animeExistente == null)
            {
                return null;
            }

            animeExistente.Nome = anime.Nome;
            animeExistente.Resumo = anime.Resumo;
            animeExistente.Diretor = anime.Diretor;

            if (string.IsNullOrEmpty(animeExistente.Nome))
            {
                return null; 
            }

            try
            {
                await _context.SaveChangesAsync();
                return animeExistente; 
            }
            catch (DbUpdateException)
            {
                return null; 
            }
        }

    }
}
