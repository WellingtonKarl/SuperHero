using Newtonsoft.Json;
using SuperHero.Domain.DTOs.Character;
using SuperHero.Domain.DTOs.Storie;
using SuperHero.Domain.Interfaces;
using SuperHero.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            var url = $"http://gateway.marvel.com/v1/public/characters{Authentication}";

            using var clientMarvel = new HttpClient();
            var result = await clientMarvel.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<CharacterDto>(content);

            return characters;
        }

        public async Task<CharacterDto> GetCharacter(int id)
        {
            var url = $"http://gateway.marvel.com/v1/public/characters/{id}{Authentication}";

            using var clientMarvel = new HttpClient();
            var result = await clientMarvel.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            var character = JsonConvert.DeserializeObject<CharacterDto>(content);

            return character;
        }
    }
}
