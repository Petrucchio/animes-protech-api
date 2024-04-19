
namespace AnimesProtech.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId);
    }
}
