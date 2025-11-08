using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            ServiceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse ;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            ServiceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.id == id);
            
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return ServiceResponse;
        }
    }
}