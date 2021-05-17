using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dasync.Collections;
using MFCD.BooruResults.e621;

namespace MFCD.Downloader
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "e621.net")]
    public class e621Downloader
    {
        private readonly HttpClient _client = new();
        private readonly int _id;
        public e621Downloader(string username, string apiKey, int workerId) // For the best experience, this is required. //
        {
            _id = workerId;
            var cred = Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{apiKey}");
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(cred)}");
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("MFCD by VelvetThePanda / v0.1a");
        }
        
        /// <summary>
        /// Gets a list of json responses for deserialization. <paramref name="take"/> should not be adjusted if <paramref name="skip"/> is defined.
        /// </summary>
        /// <param name="tags">The tags to query e621.net with.</param>
        /// <param name="take">How many pages to take.</param>
        /// <param name="skip">How many pages to skip. Defaults to 0.</param>
        /// <returns>A list of JSON responses to be deserialized into <see cref="List{Stream}"/> of <see cref="Post"/>.</returns>
        public async IAsyncEnumerable<Stream> GetContent(string tags, int take, int skip = 0)
        {
            take += skip;
            var baseUrl = "https://e621.net/posts.json?";
            
            for (int i = 1 + skip; i < take + 1; i++)
            {
                Stream contentStream = await _client.GetStreamAsync($"{baseUrl}page={i}&tags={tags.Replace(' ', '+')}");
                yield return contentStream;
            }
        }
    }
}