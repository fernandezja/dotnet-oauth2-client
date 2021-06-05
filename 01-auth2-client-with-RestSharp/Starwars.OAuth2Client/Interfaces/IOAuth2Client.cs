using Starwars.OAuth2Client.Entities;
using System.Threading.Tasks;

namespace Starwars.OAuth2Client.Interfaces
{
    public interface IOAuth2Client
    {
        Task<Token> GetTokenAsync(string url, string clientId, string clientSecret);
    }
}