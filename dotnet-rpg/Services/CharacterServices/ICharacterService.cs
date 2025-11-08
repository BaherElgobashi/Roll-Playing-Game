using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterServices
{
    public interface ICharacterService
    {
        List<Character> GetAll();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);

        
    }
}