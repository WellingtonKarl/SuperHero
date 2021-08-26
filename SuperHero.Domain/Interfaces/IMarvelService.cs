using SuperHero.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Domain.Interfaces
{
    public interface IMarvelService
    {
        Task<CharacterDto> GetAllCharacters();
    }
}
