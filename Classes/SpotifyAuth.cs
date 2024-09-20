using System;
using SpotifyAPI.Web;
using System.Threading.Tasks;
using downloaderMusic.Interfaces;

namespace downloaderMusic.Classes
{
    public class SpotifyAuth : ISpotifyAuth
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        public SpotifyAuth()
        {
            DotNetEnv.Env.Load(@"C:\\projects\\ApiDotnet---Spotify\\ApiDotnet---Spotify\\downloaderMusic\\.env");
            _clientId = "03aa58341c8b4fe0a8088500118074c1";
            _clientSecret = "410260df8b58459ab7f6be3a8ea090df";
        }

        public async Task<SpotifyClient> AuthenticateAsync()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(_clientId, _clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            return new SpotifyClient(config.WithToken(response.AccessToken));
        }
    }
}