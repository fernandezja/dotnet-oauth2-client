using System;
using System.Threading.Tasks;
using Xunit;

namespace Starwars.OAuth2Client.Tests
{
    public class OAuth2ClientTest
    {
        [Fact]
        public async Task GetTokenAsync_ToDemoIdentityServer_GetClientCredentials()
        {
            var auth2Client = new OAuth2Client();

            var token = await auth2Client.GetTokenAsync(
                                                url: "https://demo.identityserver.io/connect/token",
                                                clientId: "m2m",
                                                clientSecret: "secret");

            Assert.NotEmpty(token.AccessToken);
            Assert.Equal(3600, token.ExpiresIn);
            Assert.Equal("Bearer", token.TokenType);
            Assert.Equal("api api.scope1 api.scope2 policyserver.management policyserver.runtime scope2", token.Scope);
        }
    }
}
