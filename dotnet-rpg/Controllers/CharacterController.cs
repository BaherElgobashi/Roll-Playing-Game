using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.DTOs.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task< ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAll()
        {

            return Ok( await _characterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id)
        {

            return Ok( await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {

            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        
        public async Task<ActionResult<GetCharacterDto>>UpdatedCharacter(UpdateCharacterDto updateCharacter)
        {
            return Ok(await _characterService.UpdateCharacter(updateCharacter));
        }


    }
}