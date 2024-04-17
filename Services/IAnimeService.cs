using AnimesProtech.Models;

namespace AnimesProtech.Services
{
    public interface IAnimeService
    {
        Task<Anime> CadastrarAnime(Anime anime);
        Task<IEnumerable<Anime>> GetAnimes(string diretor, string nome, string palavrasChave, int pagina, int registrosPorPagina);
        Task<Anime> GetAnime(int id);
        Task<Anime> AtualizarAnime(int id, Anime anime);
        Task<bool> ExcluirAnime(int id);
    }
}
