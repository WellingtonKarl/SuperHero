using Newtonsoft.Json;
using SuperHero.Domain.DTOs.Character;
using SuperHero.Domain.DTOs.Comic;
using SuperHero.Domain.Interfaces;
using SuperHero.Domain.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Result = SuperHero.Domain.DTOs.Character.Result;

namespace SuperHero.Service.Services
{
    public class MarvelService : IMarvelService
    {
        private readonly MarvelAuthentication _marvelAuthentication;
        private string Authentication => $"?ts={_marvelAuthentication.TimeStamp}&apikey={_marvelAuthentication.ApiKey}&hash={_marvelAuthentication.HashMD5}";

        public MarvelService(MarvelAuthentication marvelAuthentication)
        {
            _marvelAuthentication = marvelAuthentication;
        }

        public async Task<CharacterDto> GetAllCharacters()
        {
            var offset = 100;
            var url = $"http://gateway.marvel.com/v1/public/characters{Authentication}&limit=100";

            using var clientMarvel = new HttpClient();
            var result = await clientMarvel.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<CharacterDto>(content);

            characters.Data.results = await GetAllResults(offset, int.Parse(characters.Data.total), url, characters.Data.results);

            return characters;
        }

        public async Task<CharacterDto> GetCharacter(int id)
        {
            var url = $"http://gateway.marvel.com/v1/public/characters/{id}{Authentication}";

            using var clientMarvel = new HttpClient();
            var result = await clientMarvel.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterDto>(content); 
        }

        public async Task<ComicDto> GetComicCharacter(string url)
        {
            var urlUnion = $"{url}{Authentication}";

            using var clientMarvel = new HttpClient();
            var result = await clientMarvel.GetAsync(urlUnion);
            var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ComicDto>(content);
        }

        private async Task<Result[]> GetAllResults(int offset, int total, string url, Result[] requestResults)
        {
            var results = new List<Result>();
            results.AddRange(requestResults);

            for (; offset <= total; offset += 100)
            {
                var urlJoinOffset = string.Concat(url, $"&offset={offset}");

                using var clientMarvel = new HttpClient();
                var result = await clientMarvel.GetAsync(urlJoinOffset);
                var content = await result.Content.ReadAsStringAsync();

                var characters = JsonConvert.DeserializeObject<CharacterDto>(content);

                results.AddRange(characters.Data.results);
            }

            return results.ToArray();
        }
    }
}
