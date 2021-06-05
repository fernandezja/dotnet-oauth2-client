using System;
using System.Text.Json;
using System.Threading.Tasks;
using Starwars.OAuth2Client;

namespace Starwars.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starwars.OAuth2Client!");
            Console.WriteLine("--------------------------------------");


            var auth2Client = new OAuth2Client.OAuth2Client();

            var token = await auth2Client.GetTokenAsync(
                                                url: "https://demo.identityserver.io/connect/token",
                                                clientId: "m2m",
                                                clientSecret: "secret");


           
            Console.WriteLine($" > AccessToken = {token.AccessToken}");
            Console.WriteLine($" > ExpiresIn = {token.ExpiresIn}");
            Console.WriteLine($" > TokenType = {token.TokenType}");
            Console.WriteLine($" > Scope = {token.Scope}");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
