using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.DTOs.Character;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

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
        private readonly ApplicationDbContext _context;

        public CharacterService(IMapper mapper , ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            // character.id = characters.Max(x => x.id) + 1;
            // characters.Add(character);
            _context.Characters.Add(character);
            var dbCharacters = await _context.Characters.ToListAsync();
            ServiceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var dbcharacter = await  _context.Characters.FirstAsync(c => c.id ==id);
                if(dbcharacter is null)
                {
                    throw new Exception($"Character with Id ({id}) is not found.");
                }

                characters.Remove(dbcharacter);
                ServiceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            ServiceResponse.Data = dbCharacters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await  _context.Characters.FirstOrDefaultAsync(c => c.id == id);
            
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.id == updatedCharacter.id);
                if(dbCharacter is null)
                {
                    throw new Exception($"Character with Id ({updatedCharacter.id}) is not found.");
                }
                dbCharacter.name = updatedCharacter.name;
                dbCharacter.intelligence = updatedCharacter.intelligence;
                dbCharacter.hitPoints = updatedCharacter.hitPoints;
                dbCharacter.strength = updatedCharacter.strength;
                dbCharacter.defense = updatedCharacter.defense;
                dbCharacter.Class = updatedCharacter.Class;
                ServiceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch(Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            
            return ServiceResponse;
        }
    }
}