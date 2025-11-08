using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.DTOs.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{id = 1 , name = "Sam"}
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(Character newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            ServiceResponse.Data = characters;
            return ServiceResponse ;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            var ServiceResponse = new ServiceResponse<List<Character>>();
            ServiceResponse.Data = characters;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.id == id);
            ServiceResponse.Data = character;
            return ServiceResponse;
        }
    }
}