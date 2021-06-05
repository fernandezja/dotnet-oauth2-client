using RestSharp;
using Starwars.OAuth2Client.Entities;
using Starwars.OAuth2Client.Interfaces;
using System.Text.Json;
using System.Threading.Tasks;

namespace Starwars.OAuth2Client
{
    public class OAuth2Client : IOAuth2Client
    {
        public async Task<Token> GetTokenAsync(string url, string clientId, string clientSecret)
        {

            var client = new RestClient(url);

            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded",
                    $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}",
                    ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return JsonSerializer.Deserialize<Token>(response.Content);
            }

            return null;
        }
      
    }
}
