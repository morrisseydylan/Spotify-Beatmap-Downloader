using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.IO;
using SpotifyAPI.Web;

namespace Spotify_Beatmap_Downloader
{
    class Beatmap
    {
        struct SearchResults
        {
            public struct BeatmapSet
            {
                public long Id { get; set; }
                public string Title { get; set; }
                public string Artist { get; set; }
                public string Unique_id { get; set; }
            }
            public BeatmapSet[] Beatmaps { get; set; }
        }

        static readonly HttpClient client = new();
        const string beatconnect = ""; // Removed from source. If you want to compile yourself, you must get your own Beatconnect API token.
        readonly List<string> artists;
        readonly string title;
        string searchResultArtist;
        string searchResultTitle;
        long id;
        string uniqueId;

        public Beatmap(List<SimpleArtist> artists, string title)
        {
            this.artists = new List<string>();
            foreach (SimpleArtist artist in artists)
            {
                this.artists.Add(artist.Name);
            }
            this.title = title;
        }

        string ArtistsToString(string delimiter = "")
        {
            string artists = this.artists[0];
            for (int j = 1; j < this.artists.Count; j++)
            {
                artists += delimiter + this.artists[j];
            }
            return artists;
        }

        public static string ArtistsToString(List<SimpleArtist> list, string delimiter = "")
        {
            string artists = list[0].Name;
            for (int j = 1; j < list.Count; j++)
            {
                artists += delimiter + list[j].Name;
            }
            return artists;
        }

        public bool IsDuplicate(FullTrack song)
        {
            return song.Name == title && ArtistsToString(song.Artists) == ArtistsToString();
        }

        public async Task<bool> FindBeatmap()
        {
            SearchResults results = await client.GetFromJsonAsync<SearchResults>("https://beatconnect.io/api/search/?q=" +
                ArtistsToString("%20") + "%20" + title + "&token=" + beatconnect);
            SearchResults.BeatmapSet result;
            try
            {
                result = results.Beatmaps[0];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            if (ArtistMatch(result.Artist) && TitleMatch(result.Title))
            {
                searchResultArtist = result.Artist;
                searchResultTitle = result.Title;
                id = result.Id;
                uniqueId = result.Unique_id;
                return true;
            }
            return false;
        }

        // TODO: improve matching algorithms

        bool ArtistMatch(string result)
        {
            return ArtistsToString(", ") == result;
        }

        bool TitleMatch(string result)
        {
            return title == result;
        }

        public async Task Download()
        {
            string path = $"downloads/{id} {searchResultArtist} - {searchResultTitle}.osz";
            if (File.Exists(path))
                return;
            var response = await client.GetStreamAsync("https://beatconnect.io/b/" + id.ToString() + '/' + uniqueId);
            using var fs = new FileStream(path, FileMode.CreateNew);
            await response.CopyToAsync(fs);
        }
    }
}