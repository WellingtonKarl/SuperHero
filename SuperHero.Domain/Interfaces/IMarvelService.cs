
using SuperHero.Domain.DTOs.Character;
using SuperHero.Domain.DTOs.Comic;
using System.Threading.Tasks;

namespace SuperHero.Domain.Interfaces
{
    public interface IMarvelService
    {
        Task<CharacterDto> GetAllCharacters();

        Task<CharacterDto> GetCharacter(int id);

        Task<ComicDto> GetComicCharacter(string url);
    }
}
