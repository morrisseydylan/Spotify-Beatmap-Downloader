using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.IO;
using System.Diagnostics;
using SpotifyAPI.Web;
using Ookii.Dialogs.WinForms;

namespace Spotify_Beatmap_Downloader
{
    class SpotifySession : SpotifyClient
    {
        struct TokenSet
        {
            public string Access_Token { get; set; }
            public string Refresh_Token { get; set; }
        }

        static readonly HttpClient client = new();
        const string id = "64c0217c2b0d42cebe9ef513f3359a4a";
        TokenSet tokens;
        List<SimplePlaylist> playlists;
        public List<SimplePlaylist> MyPlaylists => playlists;

        SpotifySession(TokenSet tokens, List<SimplePlaylist> playlists = null) : base(tokens.Access_Token)
        {
            this.tokens = tokens;
            this.playlists = playlists;
        }

        public static async Task<SpotifySession> Start()
        {
            if (File.Exists("tokens.txt"))
            {
                var tokens = new TokenSet();
                using (StreamReader sr = File.OpenText("tokens.txt"))
                {
                    tokens.Access_Token = sr.ReadLine();
                    tokens.Refresh_Token = sr.ReadLine();
                }
                var spotify = new SpotifySession(tokens);
                try
                {
                    return await spotify.RequestPlaylists();
                }
                catch (APIUnauthorizedException)
                {
                    spotify = new SpotifySession(await GetNewTokens(tokens));
                    return await spotify.RequestPlaylists();
                }
            }

            return await Authorize();
        }

        static async Task<SpotifySession> Authorize()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            var loginRequest = new LoginRequest(new Uri("https://example.com"), id, LoginRequest.ResponseType.Code)
            {
                CodeChallengeMethod = "S256",
                CodeChallenge = challenge,
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            Process.Start(new ProcessStartInfo
            {
                FileName = loginRequest.ToUri().ToString(),
                UseShellExecute = true
            });

            var spotifyDialog = new InputDialog
            {
                WindowTitle = "Spotify Beatmap Downloader",
                Content = "Click \"Agree\" in your browser. Then copy and paste the link to which you were redirected."
            };
            string beginningOfInput = "https://example.com/?code=";
            do
            {
                if (spotifyDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    Environment.Exit(0);
            }
            while (!spotifyDialog.Input.StartsWith(beginningOfInput) || spotifyDialog.Input.Length == beginningOfInput.Length);
            string code = spotifyDialog.Input[(spotifyDialog.Input.IndexOf('=') + 1)..];

            var spotify = new SpotifySession(await GetTokensFromResponse(await client.PostAsync("https://accounts.spotify.com/api/token",
                new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", id },
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", "https://example.com/" },
                { "code_verifier", verifier }
            }))));

            return await spotify.RequestPlaylists();
        }

        static async Task<TokenSet> GetTokensFromResponse(HttpResponseMessage response)
        {
            TokenSet tokens = await response.Content.ReadFromJsonAsync<TokenSet>();
            using (StreamWriter sw = File.CreateText("tokens.txt"))
            {
                sw.WriteLine(tokens.Access_Token);
                sw.WriteLine(tokens.Refresh_Token);
            }
            return tokens;
        }

        static async Task<TokenSet> GetNewTokens(TokenSet tokens)
        {
            return await GetTokensFromResponse(await client.PostAsync("https://accounts.spotify.com/api/token", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token" , tokens.Refresh_Token },
                { "client_id", id }
            })));
        }

        async Task<SpotifySession> RequestPlaylists()
        {
            playlists = (await Playlists.CurrentUsers()).Items;
            return this;
        }

        public async Task<SpotifySession> Refresh()
        {
            return new SpotifySession(await GetNewTokens(tokens), playlists);
        }
    }
}