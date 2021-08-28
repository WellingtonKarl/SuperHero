
using SuperHero.Domain.DTOs.Character;
using SuperHero.Domain.DTOs.Storie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Domain.Interfaces
{
    public interface IMarvelService
    {
        Task<CharacterDto> GetAllCharacters();

        Task<CharacterDto> GetCharacter(int id);
    }
}
